using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public enum NodeType
    {
        StartEnd,
        Decision,
        DataInput,
        Page,
        BackgroundProcess,
        UserProcess,
        Connection,
        HtmlElement,
        Input,
        Anchor,
        Button,
        Select,
        Image,
        None
    }
}
