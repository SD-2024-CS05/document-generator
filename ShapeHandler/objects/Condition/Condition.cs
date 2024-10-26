using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShapeHandler.Objects
{
    public class Condition<T>
    {
        public T Type { get; set; }
        public bool State { get; set; }
        public string MatchValue { get; set; }
        public Func<string, bool> Validate { get; set; } // Validation function

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Condition<T> condition = (Condition<T>)obj;
            return Type.Equals(condition.Type) && State == condition.State && MatchValue == condition.MatchValue;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, State, MatchValue);
        }
    }
}
