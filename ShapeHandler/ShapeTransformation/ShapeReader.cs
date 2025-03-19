using AngleSharp.Html.Dom;
using AngleSharp.Text;
using Microsoft.Office.Interop.Visio;
using Newtonsoft.Json;
using ShapeHandler.Helpers;
using ShapeHandler.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Visio = Microsoft.Office.Interop.Visio;

namespace ShapeHandler.ShapeTransformation
{
    public class ShapeReader
    {
        private static Dictionary<int, FlowchartNode> VisioIDToNode = new Dictionary<int, FlowchartNode>();

        #region Public Methods

        /// <summary>
        /// Converts a collection of Visio shapes to an HTML graph representation.
        /// </summary>
        /// <param name="shapes">The collection of Visio shapes to convert.</param>
        /// <returns>An HtmlGraph representing the shapes and their connections.</returns>
        public static HtmlGraph ConvertShapesToGraph(Shapes shapes)
        {
            var visioIDToGuid = new Dictionary<int, string>();
            var connections = new Dictionary<string, IDictionary<string, List<Connection>>>();
            var nodes = new List<FlowchartNode>();

            foreach (Shape shape in shapes)
            {
                if (!IsSpecialConnectorOrSheet(shape))
                {
                    var node = ConvertShapeToNode<FlowchartNode>(shape);
                    if (node != null)
                    {
                        visioIDToGuid[shape.ID] = node.Id;
                        nodes.Add(node);
                    }
                }
            }

            nodes = nodes.SkipWhile(x => x.Label != "Start")
                         .Concat(nodes.TakeWhile(x => x.Label != "Start"))
                         .ToList();

            foreach (Shape shape in shapes)
            {
                if (!IsSpecialConnectorOrSheet(shape))
                {
                    var connected = GetConnected(shape, visioIDToGuid);
                    connections[visioIDToGuid[shape.ID]] = connected;
                }
            }

            return ConvertNodesToGraph(nodes, connections);
        }

        /// <summary>
        /// Determines if a given shape is a valid decision connection.
        /// </summary>
        /// <param name="shape">The shape to check.</param>
        /// <returns>True if the shape is a valid decision connection, otherwise false.</returns>
        public static bool IsValidDecisionConnection(Shape shape)
        {
            if (VisioShapeDataHelper.GetNodeType(shape.ID) != Objects.NodeType.Connection)
            {
                return false;
            }

            var decisionNodeID = IsConnectionFromDecisionNode(shape);
            if (decisionNodeID == -1)
            {
                return false;
            }

            var decisionNode = shape.ContainingPage.Shapes.ItemFromID[decisionNodeID];
            var connectedShapeArrayTargetIDs = decisionNode.GluedShapes(VisGluedShapesFlags.visGluedShapesOutgoing1D, "");

            return connectedShapeArrayTargetIDs.Length <= 2;
        }

        /// <summary>
        /// Gets the decision node bound to a given shape.
        /// </summary>
        /// <param name="shape">The shape to check.</param>
        /// <returns>The bound decision node, or null if none is found.</returns>
        public static DecisionNode GetBoundDecisionNode(Shape shape)
        {
            if (VisioShapeDataHelper.GetNodeType(shape.ID) != Objects.NodeType.Connection)
            {
                return null;
            }

            var decisionNodeID = IsConnectionFromDecisionNode(shape);
            if (decisionNodeID == -1)
            {
                return null;
            }

            var decisionNode = shape.ContainingPage.Shapes.ItemFromID[decisionNodeID];
            return ConvertShapeToNode<DecisionNode>(decisionNode);
        }

        /// <summary>
        /// Gets the data input node bound to a given shape.
        /// </summary>
        /// <param name="shape">The shape to check.</param>
        /// <returns>The bound data input node, or null if none is found.</returns>
        public static DataInputNode GetBoundDataInputNode(Shape shape)
        {
            // Check if the shape is of type Decision
            if (VisioShapeDataHelper.GetNodeType(shape.ID) != Objects.NodeType.Decision)
            {
                return null;
            }

            // Get the IDs of shapes connected to the current shape
            var connectedShapeArrayTargetIDs = shape.GluedShapes(VisGluedShapesFlags.visGluedShapesIncoming1D, "");
            if (connectedShapeArrayTargetIDs.Length == 0)
            {
                return null;
            }

            // Iterate through each connected shape
            for (int i = connectedShapeArrayTargetIDs.GetLowerBound(0); i <= connectedShapeArrayTargetIDs.GetUpperBound(0); i++)
            {
                // Get the connection shape using its ID
                var connectionShape = shape.ContainingPage.Shapes.ItemFromID[(int)connectedShapeArrayTargetIDs.GetValue(i)];
                // Get the IDs of shapes connected to the connection shape
                var connectedShapeArraySourceIDs = connectionShape.GluedShapes(VisGluedShapesFlags.visGluedShapesIncoming2D, "");
                if (connectedShapeArraySourceIDs.Length == 0)
                {
                    continue;
                }

                // Get the connected shape using its ID
                var connectedShape = shape.ContainingPage.Shapes.ItemFromID[(int)connectedShapeArraySourceIDs.GetValue(0)];
                // Check if the connected shape is of type DataInput
                if (VisioShapeDataHelper.GetNodeType(connectedShape.ID) == Objects.NodeType.DataInput)
                {
                    // Convert the shape to a DataInputNode and return it
                    return ConvertShapeToNode<DataInputNode>(connectedShape);
                }
            }

            return null;
        }

        /// <summary>
        /// Determines if a given shape is a connection from a decision node.
        /// </summary>
        /// <param name="shape">The shape to check.</param>
        /// <returns>The ID of the decision node if found, otherwise -1.</returns>
        public static int IsConnectionFromDecisionNode(Shape shape)
        {
            // Check if the shape is of type Connection
            if (VisioShapeDataHelper.GetNodeType(shape.ID) == Objects.NodeType.Connection)
            {
                // Get the IDs of shapes connected to the current shape
                var connectedShapeArraySourceIDs = shape.GluedShapes(VisGluedShapesFlags.visGluedShapesIncoming2D, "");
                // Iterate through each connected shape
                for (int i = connectedShapeArraySourceIDs.GetLowerBound(0); i <= connectedShapeArraySourceIDs.GetUpperBound(0); i++)
                {
                    // Get the connected shape using its ID
                    var connectedShape = shape.ContainingPage.Shapes.ItemFromID[(int)connectedShapeArraySourceIDs.GetValue(i)];
                    // Check if the connected shape is of type Decision
                    if (VisioShapeDataHelper.GetNodeType(connectedShape.ID) == Objects.NodeType.Decision)
                    {
                        // Return the ID of the decision node
                        return connectedShape.ID;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Saves the node mapping to the given Visio document.
        /// </summary>
        /// <param name="doc">The Visio document.</param>
        public static void SaveNodeMappingToDocument(Visio.Document doc)
        {
            var documentSheet = doc.DocumentSheet;
            try
            {
                string serializedData = SerializeFlowchartNodes();
                var section = documentSheet.Section[(short)VisSectionIndices.visSectionUser];
                short rowIndex = FindNamedRow(section, "NodeMapping");

                if (rowIndex == -1)
                {
                    rowIndex = documentSheet.AddNamedRow((short)VisSectionIndices.visSectionUser, "NodeMapping", (short)VisRowTags.visTagDefault);
                }

                var cell = documentSheet.CellsSRC[(short)VisSectionIndices.visSectionUser, rowIndex, (short)VisCellIndices.visCustPropsValue];
                cell.FormulaU = $"\"{serializedData.Replace("\"", "\"\"")}\"";
            }
            catch { }
        }

        /// <summary>
        /// Loads the node mapping from a Visio document.
        /// </summary>
        /// <param name="doc">The Visio document to load the node mapping from.</param>
        public static void LoadNodeMappingFromDocument(Visio.Document doc)
        {
            var documentSheet = doc.DocumentSheet;
            try
            {
                var rowIndex = FindNamedRow(documentSheet.Section[(short)VisSectionIndices.visSectionUser], "NodeMapping");
                if (rowIndex != -1)
                {
                    var cell = documentSheet.CellsSRC[(short)VisSectionIndices.visSectionUser, rowIndex, (short)VisCellIndices.visCustPropsValue];
                    var serializedData = cell.ResultStrU["Value"];
                    VisioIDToNode = DeserializeFlowchartNodes(serializedData);
                }
            }
            catch { }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Serializes the flowchart nodes to a JSON string.
        /// </summary>
        /// <returns>A JSON string representing the serialized flowchart nodes.</returns>
        private static string SerializeFlowchartNodes()
        {
            var serializedDictionary = new Dictionary<int, string>();
            foreach (var kvp in VisioIDToNode)
            {
                serializedDictionary[kvp.Key] = JsonConvert.SerializeObject(kvp.Value, new FlowchartNodeSerializer());
            }

            return JsonConvert.SerializeObject(serializedDictionary);
        }

        /// <summary>
        /// Deserializes the flowchart nodes from a JSON string.
        /// </summary>
        /// <param name="serializedData">The JSON string representing the serialized flowchart nodes.</param>
        /// <returns>A dictionary mapping Visio IDs to flowchart nodes.</returns>
        private static Dictionary<int, FlowchartNode> DeserializeFlowchartNodes(string serializedData)
        {
            var deserializedDictionary = JsonConvert.DeserializeObject<Dictionary<int, string>>(serializedData);
            var result = new Dictionary<int, FlowchartNode>();
            foreach (var kvp in deserializedDictionary)
            {
                result[kvp.Key] = JsonConvert.DeserializeObject<FlowchartNode>(kvp.Value, new FlowchartNodeSerializer());
            }

            return result;
        }

        /// <summary>
        /// Gets the connections for a given shape.
        /// </summary>
        /// <param name="shape">The shape to get connections for.</param>
        /// <param name="visioIDToGuid">The dictionary mapping Visio IDs to GUIDs.</param>
        /// <returns>A dictionary of connections.</returns>
        private static IDictionary<string, List<Connection>> GetConnected(Shape shape, IDictionary<int, string> visioIDToGuid)
        {
            // Initialize a dictionary to store connections
            var connections = new Dictionary<string, List<Connection>>();

            // Get the IDs of shapes connected to the current shape
            var connectedShapeArrayTargetIDs = shape.ConnectedShapes(VisConnectedShapesFlags.visConnectedShapesOutgoingNodes, "");

            // Get the IDs of connectors glued to the current shape
            var connectorArrayTargetIDs = shape.GluedShapes(VisGluedShapesFlags.visGluedShapesOutgoing1D, "");

            // Iterate through each connected shape
            for (int i = connectedShapeArrayTargetIDs.GetLowerBound(0); i <= connectedShapeArrayTargetIDs.GetUpperBound(0); i++)
            {
                // Get the connector shape using its ID
                var connector = shape.ContainingPage.Shapes.ItemFromID[(int)connectorArrayTargetIDs.GetValue(i)];

                // Get the connected shape using its ID
                var connectedShape = shape.ContainingPage.Shapes.ItemFromID[(int)connectedShapeArrayTargetIDs.GetValue(i)];

                // Get the shape data for the connector
                var shapeData = VisioShapeDataHelper.GetShapeData(connector.ID);

                Connection connection;

                // Check if the current shape is a DataInput and the connected shape is a Decision
                if (VisioShapeDataHelper.GetNodeType(shape.ID) == Objects.NodeType.DataInput &&
                    VisioShapeDataHelper.GetNodeType(connectedShape.ID) == Objects.NodeType.Decision)
                {
                    // Create a VALIDATES connection
                    connection = new Connection(connector.Text, ConnectionType.VALIDATES);
                    AddConnection(connections, visioIDToGuid, connectedShape, connection);

                    // Create a GOES_TO connection
                    connection = new Connection(connector.Text, ConnectionType.GOES_TO);
                }
                else
                {
                    // Create a default connection
                    connection = new Connection(connector.Text);
                }

                // Check if the shape data contains a "Connection" key
                if (shapeData.ContainsKey("Connection"))
                {
                    // Deserialize the connection data
                    var serializedData = shapeData["Connection"].ToString();
                    connection = JsonConvert.DeserializeObject<Connection>(serializedData);
                    connection.Label = connector.Text;
                }

                // Add the connection to the connections dictionary
                AddConnection(connections, visioIDToGuid, connectedShape, connection);
            }
            return connections;
        }

        /// <summary>
        /// Adds a connection to the connections dictionary.
        /// </summary>
        /// <param name="connections">The dictionary of connections.</param>
        /// <param name="visioIDToGuid">The dictionary mapping Visio IDs to GUIDs.</param>
        /// <param name="connectedShape">The shape that is connected.</param>
        /// <param name="connection">The connection to add.</param>
        private static void AddConnection(IDictionary<string, List<Connection>> connections, IDictionary<int, string> visioIDToGuid, Shape connectedShape, Connection connection)
        {
            if (!connections.ContainsKey(visioIDToGuid[connectedShape.ID]))
            {
                connections[visioIDToGuid[connectedShape.ID]] = new List<Connection>();
            }
            connections[visioIDToGuid[connectedShape.ID]].Add(connection);
        }

        /// <summary>
        /// Converts a list of flowchart nodes and their connections to an HTML graph.
        /// </summary>
        /// <param name="nodes">The list of flowchart nodes.</param>
        /// <param name="connections">The dictionary of connections.</param>
        /// <returns>An HtmlGraph representing the nodes and their connections.</returns>
        private static HtmlGraph ConvertNodesToGraph(List<FlowchartNode> nodes, IDictionary<string, IDictionary<string, List<Connection>>> connections)
        {
            var htmlGraph = new HtmlGraph();
            // Add all nodes to the HTML graph
            foreach (var node in nodes)
            {
                htmlGraph.AddNode(node);
            }

            // Iterate through each node to add connections
            foreach (var node in nodes)
            {
                foreach (var connectionPair in connections[node.Id])
                {
                    // Check if the node is a DataInputNode
                    if (node is DataInputNode dataInputNode)
                    {
                        // Get the count of DataInputNodes connected to the decision node
                        var dataInputNodeBoundToDecisionNodeCount = htmlGraph.GetConnectedNodesTo(nodes.Find(x => x.Id == connectionPair.Key)).Keys.OfType<DataInputNode>().Count();
                        // Check if the DataInputNode is already connected
                        var dataInputNodeAlreadyConnected = htmlGraph.GetConnectedNodesTo(nodes.Find(x => x.Id == connectionPair.Key)).ContainsKey(dataInputNode);
                        // Check if the DataInputNode has elements
                        var hasElements = dataInputNode.DataInputNodes.Count() != 0;
                        // Add connection if bound to a decision node, not already connected, and has elements
                        if (dataInputNodeBoundToDecisionNodeCount == 0 && !dataInputNodeAlreadyConnected && hasElements)
                        {
                            foreach (var conn in connectionPair.Value)
                            {
                                htmlGraph.AddConnection(node, nodes.Find(x => x.Id == connectionPair.Key), conn);
                            }
                        }
                    }
                    else
                    {
                        // Add connection for non-DataInputNode nodes
                        foreach (var conn in connectionPair.Value)
                        {
                            htmlGraph.AddConnection(node, nodes.Find(x => x.Id == connectionPair.Key), conn);
                        }
                    }
                }
            }
            return htmlGraph;
        }

        /// <summary>
        /// Converts a Visio shape to a flowchart node of a specified type.
        /// </summary>
        /// <typeparam name="T">The type of flowchart node to convert to.</typeparam>
        /// <param name="shape">The Visio shape to convert.</param>
        /// <returns>The converted flowchart node.</returns>
        private static T ConvertShapeToNode<T>(Shape shape) where T : FlowchartNode
        {
            if (VisioIDToNode.TryGetValue(shape.ID, out FlowchartNode fNode))
            {
                return fNode as T;
            }

            var shapeData = VisioShapeDataHelper.GetShapeData(shape.ID);
            var htmlElements = VisioShapeDataHelper.GetHtmlElements(shape.ID);
            var type = VisioShapeDataHelper.GetNodeType(shape.ID);
            dynamic node = null;

            switch (type)
            {
                case Objects.NodeType.StartEnd:
                    node = CreateStartEndNode(shapeData);
                    break;
                case Objects.NodeType.Decision:
                    node = CreateDecisionNode(shape, htmlElements);
                    break;
                case Objects.NodeType.DataInput:
                    node = CreateDataInputNode(shape, htmlElements);
                    break;
                case Objects.NodeType.UserProcess:
                    node = new ProcessNode(shape.Text, false);
                    break;
                case Objects.NodeType.BackgroundProcess:
                    node = new ProcessNode(shape.Text, true);
                    break;
                case Objects.NodeType.Page:
                    node = new PageNode(shape.Text) { URL = shapeData["URL"]?.ToString() };
                    break;
            }

            if (node != null)
            {
                VisioIDToNode[shape.ID] = node;
            }

            return node as T;
        }

        /// <summary>
        /// Creates a StartEndNode from the given shape data.
        /// </summary>
        /// <param name="shapeData">The shape data dictionary.</param>
        /// <returns>A StartEndNode object.</returns>
        private static StartEndNode CreateStartEndNode(Dictionary<string, object> shapeData)
        {
            bool isStart = shapeData["IsStart"].ToString().ToBoolean();
            string url = shapeData["URL"]?.ToString();
            var label = isStart ? "Start" : "End";
            return new StartEndNode(label, isStart) { URL = url };
        }

        /// <summary>
        /// Creates a DecisionNode from the given shape and HTML elements.
        /// </summary>
        /// <param name="shape">The Visio shape.</param>
        /// <param name="htmlElements">The list of HTML elements.</param>
        /// <returns>A DecisionNode object.</returns>
        private static DecisionNode CreateDecisionNode(Shape shape, List<IHtmlElement> htmlElements)
        {
            var node = new DecisionNode(shape.Text);
            htmlElements.ForEach(he =>
            {
                var nodeType = VisioShapeDataHelper.GetHtmlElementNodeType(he);
                var htmlNode = new HtmlNode(he.Id, he, nodeType);
                node.SubmissionNodes.Add(htmlNode);
            });
            return node;
        }

        /// <summary>
        /// Creates a DataInputNode from the given shape and HTML elements.
        /// </summary>
        /// <param name="shape">The Visio shape.</param>
        /// <param name="htmlElements">The list of HTML elements.</param>
        /// <returns>A DataInputNode object.</returns>
        private static DataInputNode CreateDataInputNode(Shape shape, List<IHtmlElement> htmlElements)
        {
            var node = new DataInputNode(shape.Text);
            htmlElements.ForEach(he =>
            {
                var nodeType = VisioShapeDataHelper.GetHtmlElementNodeType(he);
                var htmlNode = new HtmlNode(he.Id, he, nodeType);
                node.DataInputNodes.Add(htmlNode);
            });
            return node;
        }

        /// <summary>
        /// Finds a named row in a Visio section.
        /// </summary>
        /// <param name="section">The Visio section to search.</param>
        /// <param name="name">The name of the row to find.</param>
        /// <returns>The index of the named row, or -1 if not found.</returns>
        private static short FindNamedRow(Visio.Section section, string name)
        {
            for (short i = 0; i < section.Count; i++)
            {
                if (section[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Determines if a given shape is a special connector or sheet.
        /// </summary>
        /// <param name="shape">The shape to check.</param>
        /// <returns>True if the shape is a special connector or sheet, otherwise false.</returns>
        private static bool IsSpecialConnectorOrSheet(Shape shape)
        {
            var isSpecialConnector = VisioShapeDataHelper.GetNodeType(shape.ID) == Objects.NodeType.Connection;
            var isSheet = Regex.IsMatch(shape.Name, "\\W*((?i)Sheet(?-i))\\W*");
            return isSpecialConnector || isSheet;
        }

        #endregion Private Methods
    }
}