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
            if (!(obj is Condition<T> otherCondition))
            {
                return false;
            }

            bool typeEquals = EqualityComparer<T>.Default.Equals(Type, otherCondition.Type);
            bool stateEquals = State == otherCondition.State;
            bool matchValueEquals = MatchValue == otherCondition.MatchValue;

            return typeEquals && stateEquals && matchValueEquals;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, State, MatchValue, Validate);
        }
    }
}
