using System.Collections.Generic;

namespace JasonGraf
{
    public class JasonNodeFactory
    {
        public static JasonNode Create(IDictionary<string, object> data)
        {
            var jasonNode = new GenericJasonNode();
            jasonNode.Parse(data);
            return jasonNode;
        }
    }
}