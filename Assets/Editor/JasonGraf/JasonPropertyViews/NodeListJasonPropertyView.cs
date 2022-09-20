using JasonGraf.JasonProperty;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;

namespace JasonGraf.JasonPropertyViews
{
    public class NodeListJasonPropertyView : BaseJasonPropertyView
    {
        public new NodeListJasonProperty Property;
        public Port Port;

        public NodeListJasonPropertyView(NodeListJasonProperty property, JasonNode jasonNode)
            : base(property, jasonNode)
        {
            Property = property;
        }

        public override void CreatePorts(JasonNodePorts ports)
        {
            Port = ports.AddPort(this, true);
        }

        public override void RemovePorts(JasonNodePorts ports)
        {
            ports.RemovePort(Port);
        }

        public override void CreateChildNodes(JasonGrafView graph)
        {
            foreach (var node in Property.Value)
            {
                var nodeView = graph.CreateNodeView(node);
                graph.CreateEdge(Port, nodeView.Input);
            }
        }

        public override void ReleaseChildNodes(JasonGrafView graph)
        {
            graph.DeleteElements(Port.connections);
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