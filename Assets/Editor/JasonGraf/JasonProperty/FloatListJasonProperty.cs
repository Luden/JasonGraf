using System;
using System.Collections.Generic;
using System.Globalization;

namespace JasonGraf.JasonProperty
{
    public class FloatListJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.FloatList;
        public List<float> Value;

        public override void Parse(object value)
        {
            Value = new List<float>();
            var valueList = (List<object>)value;
            foreach (var e in valueList)
            {
                Value.Add(Convert.ToSingle(e, NumberFormatInfo.InvariantInfo));
            }
        }

        public override object Serialize()
        {
            return Value;
        }
    }
}