using System;

namespace JasonGraf.JasonProperty
{
    public class StringJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.String;
        public string Value;

        public override void Parse()
        {
            Value = Convert.ToString(ParentNode[Name]);
        }

        public override void Commit()
        {
            ParentNode[Name] = Value;
        }
    }
}