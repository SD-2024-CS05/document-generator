using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace ShapeHandler.Objects
{
    public class Conditions
    {
        public List<string> NodeIds { get; set; }

        public LogicalOperator Operator { get; set; }

        public Conditions InnerConditions { get; set; }

        public Conditions()
        {
            NodeIds = new List<string>();
        }

        public Conditions(LogicalOperator op)
        {
            Operator = op;
            NodeIds = new List<string>();
        }

        public Conditions(LogicalOperator op, List<string> nodeIds)
        {
            Operator = op;
            NodeIds = nodeIds;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            builder.Append($"\"operator\": \"{Operator.ToString().ToUpper()}\", ");
            builder.Append("\"nodeIds\": [");
            for (int i = 0; i < NodeIds.Count; i++)
            {
                builder.Append($"\"{NodeIds[i]}\"");
                if (i < NodeIds.Count - 1)
                {
                    builder.Append(", ");
                }
            }
            builder.Append("]");
            if (InnerConditions != null)
            {
                builder.Append($", \"innerCondition\": {InnerConditions}");
            }
            builder.Append("}");
            return builder.ToString();
        }
    }
    public enum LogicalOperator
    {
        AND,
        OR,
        NOT,
        XOR,
        NOR,
        NAND
    }
}
