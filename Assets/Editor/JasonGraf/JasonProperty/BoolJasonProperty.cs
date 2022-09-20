using System;

namespace JasonGraf.JasonProperty
{
    public class BoolJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.Bool;
        public bool Value;

        public override void Parse(object value)
        {
            Value = Convert.ToBoolean(value);
        }

        public override object Serialize()
        {
            return Value;
        }
    }
}