using System.Collections.Generic;
using JasonGraf.JasonPropertyViews;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace JasonGraf
{
    public class JasonNodePorts
    {
        private JasonNodeView _nodeView;
        private Dictionary<Port, BaseJasonPropertyView> _portOwners = new Dictionary<Port, BaseJasonPropertyView>();

        public JasonNodePorts(JasonNodeView nodeView)
        {
            _nodeView = nodeView;
        }

        public Port AddPort(BaseJasonPropertyView propertyView, bool isMulti)
        {
            var generatedPort = _nodeView.InstantiatePort(Orientation.Horizontal, Direction.Output, isMulti ? Port.Capacity.Multi : Port.Capacity.Single, typeof(bool));
            var portLabel = generatedPort.contentContainer.Q<Label>("type");
            generatedPort.contentContainer.Remove(portLabel);

            var textField = new TextField()
            {
                name = string.Empty,
                value = propertyView.Property.Name
            };
            textField.RegisterValueChangedCallback(evt => generatedPort.portName = evt.newValue);
            generatedPort.contentContainer.Add(new Label("  "));
            generatedPort.contentContainer.Add(textField);
            var deleteButton = new Button(() => RemovePort(generatedPort))
            {
                text = "X"
            };
            generatedPort.contentContainer.Add(deleteButton);
            generatedPort.portName = propertyView.Property.Name;
            _nodeView.outputContainer.Add(generatedPort);
            _nodeView.RefreshPorts();
            _nodeView.RefreshExpandedState();
            _portOwners[generatedPort] = propertyView;
            return generatedPort;
        }

        public BaseJasonPropertyView GetPortOwner(Port port)
        {
            _portOwners.TryGetValue(port, out var owner);
            return owner;
        }

        private void RemovePort(Port port)
        {
            _nodeView.outputContainer.Remove(port);
            _nodeView.RefreshPorts();
            _nodeView.RefreshExpandedState();
            _portOwners.Remove(port);
        }
    }
}