using JasonGraf.JasonProperty;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;

namespace JasonGraf.JasonPropertyViews
{
    public class NodeJasonPropertyView : BaseJasonPropertyView
    {
        public new NodeJasonProperty Property;
        public Port Port;

        public NodeJasonPropertyView(NodeJasonProperty property, JasonNode jasonNode)
            : base(property, jasonNode)
        {
            Property = property;
        }

        public override void CreatePorts(JasonNodePorts ports)
        {
            Port = ports.AddPort(this, false);
        }

        public override void RemovePorts(JasonNodePorts ports)
        {
            ports.RemovePort(Port);
        }

        public override void CreateChildNodes(JasonGrafView graph)
        {
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