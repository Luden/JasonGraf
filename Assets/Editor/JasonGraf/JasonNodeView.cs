using UnityEditor.Experimental.GraphView;

namespace JasonGraf
{
    public class JasonNodeView : Node
    {

        public JasonNodeView(JasonNode node)
        {
            this.title = node.Id;
        }
    }
}