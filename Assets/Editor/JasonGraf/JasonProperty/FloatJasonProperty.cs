using System;

namespace JasonGraf.JasonProperty
{
    public class FloatJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.Float;
        public float Value;

        public override void Parse()
        {
            Value = Convert.ToSingle(ParentNode[Name]);
        }

        public override void Commit()
        {
            ParentNode[Name] = Value;
        }
    }
}