using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class Connection
    {
        public string Label { get; set; }
        public List<Condition> Conditions { get; set; }
        public ConnectionType Type { get; set; }

        public Connection(string label)
        {
            Label = label;
            Conditions = new List<Condition>();
            Type = ConnectionType.GOES_TO;
        }

        public Connection(string label, ConnectionType type)
        {
            Label = label;
            Conditions = new List<Condition>();
            Type = type;
        }

        public Connection(string label, List<Condition> conditions)
        {
            Label = label;
            Conditions = conditions;
            Type = ConnectionType.GOES_TO;

        }

        public Connection(string label, List<Condition> conditions, ConnectionType type)
        {
            Label = label;
            Conditions = conditions;
            Type = type;
            Type = ConnectionType.GOES_TO;
        }

        public override bool Equals(object obj)
        {
            return obj is Connection connection &&
                   Label == connection.Label &&
                   EqualityComparer<List<Condition>>.Default.Equals(Conditions, connection.Conditions) &&
                   Type == connection.Type;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"{{");
            builder.Append($"label: \"{Label}\", ");
            builder.Append($"type: \"{Type.ToString().ToUpper()}\", ");
            builder.Append($"conditions: [");
            foreach (var condition in Conditions)
            {
                builder.Append($"{condition}, ");
            }
            builder.Append($"]");
            builder.Append($"}}");

            return builder.ToString();
        }
    }

    public enum ConnectionType
    {
        DIRECTS_TO,
        GOES_TO,
        INPUT_FOR,
        VALIDATES,
        SUBMITS,
        RESETS,
        CLICKS,
        HOVERS_OVER,
        DRAGS,
        DROPS
    }
}
