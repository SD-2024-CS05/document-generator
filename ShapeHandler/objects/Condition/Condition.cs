using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShapeHandler
{
    public class Condition<T>
    {
        public T Type { get; set; }
        public bool State { get; set; }
        public string MatchValue { get; set; }

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

        public static Condition<T> FromXElement(XElement element)
        {
            return new Condition<T>
            {
                Type = (T)Enum.Parse(typeof(T), element.Attribute("Type").Value),
                State = bool.Parse(element.Attribute("State").Value),
                MatchValue = element.Attribute("MatchValue").Value
            };
        }
    }
}
