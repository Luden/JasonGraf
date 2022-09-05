using System;
using System.Collections.Generic;
using System.Globalization;

namespace JasonGraf.JasonProperty
{
    public class FloatListJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.FloatList;
        public List<float> Value;

        public override void Parse()
        {
            Value = new List<float>();
            if (ParentNode.TryGetValue(Name, out var value))
            {
                foreach (var e in (List<object>)value)
                {
                    Value.Add(Convert.ToSingle(e, NumberFormatInfo.InvariantInfo));
                }
            }
        }

        public override void Commit()
        {
            ParentNode[Name] = Value;
        }
    }
}