using System;
using System.Collections.Generic;
using ShapeHandler.Objects;

namespace ShapeHandler.ShapeTransformation
{
    //public class VisioShape
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public NodeType Type { get; set; }
    //    public List<VisioConnector> Connections { get; set; }
    //    //public IDictionary<int, string> Connections { get; set; }
    //    public IDictionary<string, string> ShapeData { get; set; }
    //}

    public class VisioConnector
    {
        public string Name { get; set; }
        public int ConnectedShapeID { get; set; }
    }

    public class NodesNCrap
    {
        public int VisioID { get; set; }
        public string Name { get; set; }
        public dynamic Node { get; set; }
        public List<VisioConnector> Connections { get; set; }
        public IDictionary<string, string> ShapeData { get; set; }
    }
}