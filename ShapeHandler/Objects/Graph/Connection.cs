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
        public Conditions Conditions { get; set; }
        public ConnectionType Type { get; set; }
        public string SubmissionId { get; set; } // optional string for a submission event id
        public string Url {get; set;} // optional url atttribute

        public Connection(string label)
        {
            Label = label;
            Type = ConnectionType.GOES_TO;
        }

        public Connection(ConnectionType type)
        {
            Type = type;
        }
          
        public Connection(ConnectionType type, string url)
        {
            Type = type;
            Url = url;
        }

        public Connection(string label, ConnectionType type)
        {
            Label = label;
            Type = type;
        }

        // url attribute added
        public Connection(string label, ConnectionType type, string url)
        {
            Label = label;
            Type = type;
            Url = url;
        }


        public Connection(string label, Conditions condition)
        {
            Label = label;
            Conditions = condition;
            Type = ConnectionType.GOES_TO;

        }


        public Connection(string label, Conditions condition, ConnectionType type)
        {
            Label = label;
            Conditions = condition;
            Type = type;
            Type = ConnectionType.GOES_TO;
        }


        public Connection(string label, Conditions condition, ConnectionType type, string submissionId)
        {
            Label = label;
            Conditions = condition;
            Type = type;
            SubmissionId = submissionId;
        }

        // url attribute added
        public Connection(string label, Conditions condition, ConnectionType type, string submissionId, string url)
        {
            Label = label;
            Conditions = condition;
            Type = type;
            SubmissionId = submissionId;
            Url = url;
        }

        public Connection(string label, string submissionId)
        {
            Label = label;
            Type = ConnectionType.GOES_TO;
            SubmissionId = submissionId;
        }

        // url attribute added
        public Connection(string label, string submissionId, string url)
        {
            Label = label;
            Type = ConnectionType.GOES_TO;
            SubmissionId = submissionId;
            Url = url;
        }

        public Connection(string label, Conditions condition, string submissionId)
        {
            Label = label;
            Conditions = condition;
            Type = ConnectionType.GOES_TO;
            SubmissionId = submissionId;
        }



        public override bool Equals(object obj)
        {
            return obj is Connection connection &&
                   Label == connection.Label &&
                   EqualityComparer<Conditions>.Default.Equals(Conditions, connection.Conditions) &&
                   Type == connection.Type;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            // return string that can be written to neo4j
            builder.Append($"{{");
            if (SubmissionId != null)
            {
                builder.Append($"submissionId: \"{SubmissionId}\", ");
            }
            builder.Append($"label: \"{Label ?? Type.ToString().ToUpper()}\", ");
            if (Conditions != null && Conditions.NodeIds.Any())
            {
                builder.Append($"conditions: {Conditions}, ");
            }
            builder.Append($"type: \"{Type.ToString().ToUpper()}\"");
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
