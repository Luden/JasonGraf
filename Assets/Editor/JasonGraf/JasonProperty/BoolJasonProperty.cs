using System;

namespace JasonGraf.JasonProperty
{
    public class BoolJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.Bool;
        public bool Value;

        public override void Parse()
        {
            Value = Convert.ToBoolean(ParentNode[Name]);
        }

        public override void Commit()
        {
            ParentNode[Name] = Value;
        }
    }
}