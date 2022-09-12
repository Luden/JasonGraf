using System.Collections.Generic;
using System.Linq;

namespace JasonGraf.JasonProperty
{
    public class NodeListJasonProperty : BaseJasonProperty
    {
        public override JasonPropertyType Type => JasonPropertyType.NodeList;
        public List<JasonNode> Value;

        public override void Parse()
        {
            Value = new List<JasonNode>();
            var nodeList = (List<object>)ParentNode[Name];
            foreach (var objNode in nodeList)
            {
                var node = objNode as IDictionary<string, object>;
                var jasonNode = JasonNodeFactory.Create(Name, node);
                Value.Add(jasonNode);
            }
        }

        public override void Commit()
        {
            ParentNode[Name] = Value
                .Select(x => x.Serialize())
                .ToList();
        }
    }
}