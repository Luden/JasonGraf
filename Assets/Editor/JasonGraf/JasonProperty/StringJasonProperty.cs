using System;

namespace JasonGraf.JasonProperty
{
    public class StringJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.String;
        public string Value;

        public override void Parse(object value)
        {
            Value = Convert.ToString(value);
        }

        public override object Serialize()
        {
            return Value;
        }
    }
}