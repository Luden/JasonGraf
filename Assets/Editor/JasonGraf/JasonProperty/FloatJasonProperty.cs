using System;

namespace JasonGraf.JasonProperty
{
    public class FloatJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.Float;
        public float Value;

        public override void Parse(object value)
        {
            Value = Convert.ToSingle(value);
        }

        public override object Serialize()
        {
            return Value;
        }
    }
}