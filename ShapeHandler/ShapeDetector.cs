using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Objects;
using ShapeHandler.Identity;
using ShapeHandler.Database;

namespace ShapeHandler
{
    public partial class ShapeDetector
    {
        private void ShapeDetector_Startup(object sender, System.EventArgs e)
        {
            KeyVaultManager manager = new KeyVaultManager();
            string username = manager.GetSecretAsync("Neo4JUsername").Result;
            string password = manager.GetSecretAsync("Neo4JPassword").Result;
            string uri = manager.GetSecretAsync("Neo4JURI").Result;

            DatabaseConnector database = new DatabaseConnector(uri, username, password);

            //database.WriteHtmlGraphAsync(CreateGraph()).Wait();
        }

        private void ShapeDetector_Shutdown(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Returns the Graph object that represents the flowchart
        /// </summary>
        /// <returns>An HtmlGraph Object</returns>
        public static HtmlGraph CreateGraph()
        {

            HtmlGraph htmlGraph = new HtmlGraph();

            htmlGraph.AddNode(new StartEndNode("1"));
            htmlGraph.AddNode(new DecisionNode("2"));

            htmlGraph.AddConnection("1", "2", new Condition<Enum>
            {
                Type = NodeType.Decision,
                State = true,
                MatchValue = "Yes",
                Validate = (string value) => value == "Yes"
            });

            return htmlGraph;
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ShapeDetector_Startup);
            this.Shutdown += new System.EventHandler(ShapeDetector_Shutdown);
        }

        #endregion
    }
}
