using System.Collections.Generic;

namespace JasonGraf.JasonProperty
{
    public class NodeJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.Node;
        public JasonNode Value;

        public override void Parse()
        {
            var node = ParentNode[Name] as IDictionary<string, object>;
            Value = JasonNodeFactory.Create(Name, node);
        }

        public override void Commit()
        {
            ParentNode[Name] = Value.Serialize();
        }
    }
}