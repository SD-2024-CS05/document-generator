using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class ConditionList
    {
        public LogicalOperator Operator { get; set; }
       
        public List<Condition> BaseConditions { get; set; }

        public ConditionList InnerConditions { get; set; }

        public ConditionList() { }

        public ConditionList(LogicalOperator op, List<Condition> conditions)
        {
            Operator = op;
            BaseConditions = conditions;
        }

        public override string ToString()
        {
            // return a neo4j writable string
            StringBuilder builder = new StringBuilder();
            builder.Append($"{{");
            builder.Append($"operator: \"{Operator.ToString().ToUpper()}\", ");
            builder.Append($"baseConditions: [");
            foreach (var condition in BaseConditions)
            {
                builder.Append($"{condition.ToString()}, ");
            }
            builder.Append($"], ");
            if (InnerConditions != null)
            {
                builder.Append($"innerConditions: {InnerConditions.ToString()}");
            }
            builder.Append($"}}");
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
