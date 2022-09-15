using JasonGraf.JasonProperty;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;

namespace JasonGraf.JasonPropertyViews
{
    public class NodeListJasonPropertyView : BaseJasonPropertyView
    {
        public new NodeListJasonProperty Property;
        public Port Port;

        public NodeListJasonPropertyView(NodeListJasonProperty property)
            : base(property)
        {
            Property = property;
        }

        public override void CreateChildNodes(JasonGrafView graph, JasonNodePorts ports)
        {
            Port = ports.AddPort(this, true);
            foreach (var node in Property.Value)
            {
                var nodeView = graph.CreateNodeView(node);
                graph.CreateEdge(Port, nodeView.Input);
            }
        }

        public override void AttachNode(JasonNodeView node)
        {
            Property.Value.Add(node.Node);
        }

        public override void DetachNode(JasonNodeView node)
        {
            Property.Value.Remove(node.Node);
        }
    }
}