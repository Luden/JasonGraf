using System.Collections.Generic;
using JasonGraf.JasonPropertyViews;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace JasonGraf
{
    public class JasonNodeView : Node
    {
        public readonly JasonNode Node;
        public readonly Port Input;
        public readonly List<BaseJasonPropertyView> Views = new List<BaseJasonPropertyView>();

        private readonly JasonNodePorts _ports;

        public JasonNodeView(JasonGrafView graph, JasonNode node)
        {
            Node = node;
            title = Node.Id;

            style.left = Node.Position.x;
            style.top = Node.Position.y;
            _ports = new JasonNodePorts(this);

            Input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
            Input.portName = "";
            inputContainer.Add(Input);

            CreatePropertyViews(graph);
        }

        public override void SetPosition(Rect newPos)
        {
            base.SetPosition(newPos);
            Node.Position.x = newPos.xMin;
            Node.Position.y = newPos.yMin;
        }

        public void AttachNode(Port port, JasonNodeView node)
        {
            var owner = _ports.GetPortOwner(port);
            if (owner != null)
                owner.AttachNode(node);
        }

        public void DetachNode(Port port, JasonNodeView node)
        {
            var owner = _ports.GetPortOwner(port);
            if (owner != null)
                owner.DetachNode(node);
        }

        private void CreatePropertyViews(JasonGrafView graph)
        {
            foreach (var property in Node.Properties.Values)
            {
                var view = JasonPropertyViewFactory.Create(property);
                view.CreateChildNodes(graph, _ports);
                extensionContainer.Add(view);
                Views.Add(view);
            }
        }
    }
}