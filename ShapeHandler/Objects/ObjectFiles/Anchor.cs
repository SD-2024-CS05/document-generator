using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Office.Interop.Visio;
using ShapeHandler;

namespace ShapeHandler
{
    public enum AnchorConditionType
    {
        Click,
        Href,
        Rel
    }

    public class Anchor : WebElement
    {
        public string Href { get; set; }
        public string Target { get; set; }
        public string Rel { get; set; }
        public List<Condition<AnchorConditionType>> Conditions { get; set; }
    }
}
