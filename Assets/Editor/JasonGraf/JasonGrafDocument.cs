using System.Collections.Generic;
using System.Linq;

namespace JasonGraf
{
    public class JasonGrafDocument
    {
        public List<JasonNode> Nodes = new List<JasonNode>();

        private static int _nodeNameIndex = 1;

        public JasonNode AddNode(string id = "")
        {
            var data = new Dictionary<string, object>();
            if (string.IsNullOrEmpty(id))
                id = GenerateId();
            var node = JasonNodeFactory.Create(id, data);
            Nodes.Add(node);
            return node;
        }

        public void AddNode(JasonNode node)
        {
            Nodes.Add(node);
        }

        public void RemoveNode(JasonNode node)
        {
            Nodes.Remove(node);
        }

        public void Parse(IDictionary<string, object> jsonDocument)
        {
            Nodes.Clear();
            foreach (var pair in jsonDocument)
            {
                var id = pair.Key;
                var data = (IDictionary<string, object>)pair.Value;
                var node = JasonNodeFactory.Create(id, data);
                Nodes.Add(node);
            }
        }

        public Dictionary<string, object> Serialize()
        {
            var result = new Dictionary<string, object>();
            foreach (var node in Nodes)
                result[node.Id] = node.Serialize();
            return result;
        }

        private string GenerateId()
        {
            var indexStr = _nodeNameIndex.ToString();
            while (Nodes.Any(x => x.Id == indexStr))
            {
                _nodeNameIndex++;
                indexStr = _nodeNameIndex.ToString();
            }
            return indexStr;
        }
    }
}