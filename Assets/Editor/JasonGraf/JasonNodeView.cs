using System.Collections.Generic;
using System.Linq;
using JasonGraf.JasonProperty;
using JasonGraf.JasonPropertyViews;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace JasonGraf
{
    public class JasonNodeView : Node
    {
        public readonly JasonNode Node;
        public readonly Port Input;

        private readonly List<BaseJasonPropertyView> _views = new List<BaseJasonPropertyView>();
        private readonly JasonNodePorts _ports;
        private readonly JasonGrafView _graph;

        public JasonNodeView(JasonGrafView graph, JasonNode node)
        {
            _graph = graph;
            Node = node;
            Node.PropertyRemoved += OnPropertyRemoved;
            Node.PropertyAdded += OnPropertyAdded;
            title = Node.Id;

            style.left = Node.Position.x;
            style.top = Node.Position.y;
            _ports = new JasonNodePorts(this);

            Input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
            Input.portName = "";
            inputContainer.Add(Input);

            foreach (var property in Node.Properties)
                AddPropertyView(property);
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

        private void RemovePropertyView(BaseJasonProperty property)
        {
            var view = _views.FirstOrDefault(x => x.Property == property);
            if (view == null)
                return;
            view.ReleaseChildNodes(_graph);
            view.RemovePorts(_ports);
            _views.Remove(view);
            extensionContainer.Remove(view);
        }

        private void AddPropertyView(BaseJasonProperty property)
        {
            var view = JasonPropertyViewFactory.Create(property, Node);
            view.CreatePorts(_ports);
            view.CreateChildNodes(_graph);
            extensionContainer.Add(view);
            _views.Add(view);
        }

        private void OnPropertyRemoved(BaseJasonProperty property)
        {
            RemovePropertyView(property);
        }

        private void OnPropertyAdded(BaseJasonProperty property)
        {
            AddPropertyView(property);
        }
    }
}