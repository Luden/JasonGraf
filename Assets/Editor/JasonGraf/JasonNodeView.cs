using UnityEditor.Experimental.GraphView;

namespace JasonGraf
{
    public class JasonNodeView : Node
    {
        public JasonNode Node;

        public JasonNodeView(JasonNode node)
        {
            Node = node;
            title = node.Id;
        }
    }
}