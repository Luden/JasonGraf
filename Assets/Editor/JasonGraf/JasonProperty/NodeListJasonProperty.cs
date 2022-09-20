using System.Collections.Generic;
using System.Linq;

namespace JasonGraf.JasonProperty
{
    public class NodeListJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.NodeList;
        public List<JasonNode> Value = new List<JasonNode>();

        public override void Parse(object value)
        {
            Value = new List<JasonNode>();
            var nodeList = (List<object>)value;
            foreach (var objNode in nodeList)
            {
                var node = objNode as IDictionary<string, object>;
                var jasonNode = JasonNodeFactory.Create(Name, node);
                Value.Add(jasonNode);
            }
        }

        public override object Serialize()
        {
            return Value
                .Select(x => x.Serialize())
                .ToList();
        }
    }
}