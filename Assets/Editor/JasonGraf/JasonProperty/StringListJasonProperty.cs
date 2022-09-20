using System;
using System.Collections.Generic;

namespace JasonGraf.JasonProperty
{
    public class StringListJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.StringList;
        public List<string> Value;

        public override void Parse(object value)
        {
            Value = new List<string>();
            var valueList = (List<object>)value;
            foreach (var e in valueList)
            {
                Value.Add(Convert.ToString(e));
            }
        }

        public override object Serialize()
        {
            return Value;
        }
    }
}