using System.Collections.Generic;

namespace JasonGraf
{
    public class JasonNodeFactory
    {
        public static JasonNode Create(string id, IDictionary<string, object> data)
        {
            var jasonNode = new GenericJasonNode();
            jasonNode.Id = id;
            jasonNode.Parse(data);
            return jasonNode;
        }
    }
}