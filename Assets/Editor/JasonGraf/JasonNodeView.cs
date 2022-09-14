using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace JasonGraf
{
    public class JasonNodeView : Node
    {
        public JasonNode Node;

        public JasonNodeView(JasonNode node)
        {
            Node = node;
            title = Node.Id;

            style.left = Node.Position.x;
            style.top = Node.Position.y;
        }

        public override void SetPosition(Rect newPos)
        {
            base.SetPosition(newPos);
            Node.Position.x = newPos.xMin;
            Node.Position.y = newPos.yMin;
        }
    }
}