using System.Collections.Generic;

namespace JasonGraf.JasonProperty
{
    public class NodeJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.Node;
        public JasonNode Value;

        public override void Parse(object value)
        {
            var node = value as IDictionary<string, object>;
            Value = JasonNodeFactory.Create(Name, node);
        }

        public override object Serialize()
        {
            return Value.Serialize();
        }
    }
}