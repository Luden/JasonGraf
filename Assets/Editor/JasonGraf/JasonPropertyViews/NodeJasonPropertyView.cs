using JasonGraf.JasonProperty;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;

namespace JasonGraf.JasonPropertyViews
{
    public class NodeJasonPropertyView : BaseJasonPropertyView
    {
        public new NodeJasonProperty Property;
        public Port Port;

        public NodeJasonPropertyView(NodeJasonProperty property)
            : base(property)
        {
            Property = property;
        }

        public override void CreateChildNodes(JasonGrafView graph, JasonNodePorts ports)
        {
            Port = ports.AddPort(this, false);
            if (Property.Value != null)
            {
                var nodeView = graph.CreateNodeView(Property.Value);
                graph.CreateEdge(Port, nodeView.Input);
            }
        }

        public override void AttachNode(JasonNodeView node)
        {
            Property.Value = node.Node;
        }

        public override void DetachNode(JasonNodeView node)
        {
            Property.Value = null;
        }
    }
}