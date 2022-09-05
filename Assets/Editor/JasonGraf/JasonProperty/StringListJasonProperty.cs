using System;
using System.Collections.Generic;

namespace JasonGraf.JasonProperty
{
    public class StringListJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.StringList;
        public List<string> Value;

        public override void Parse()
        {
            Value = new List<string>();
            if (ParentNode.TryGetValue(Name, out var value))
            {
                foreach (var e in (List<object>)value)
                {
                    Value.Add(Convert.ToString(e));
                }
            }
        }

        public override void Commit()
        {
            ParentNode[Name] = Value;
        }
    }
}