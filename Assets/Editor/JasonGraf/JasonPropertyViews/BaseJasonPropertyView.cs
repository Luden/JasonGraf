using JasonGraf.JasonProperty;
using UnityEngine.UIElements;

namespace JasonGraf.JasonPropertyViews
{
    public class BaseJasonPropertyView : VisualElement
    {
        public readonly BaseJasonProperty Property;
        public readonly JasonNode Owner;

        public BaseJasonPropertyView(BaseJasonProperty property, JasonNode jasonNode)
        {
            Property = property;
            Owner = jasonNode;
        }

        public virtual void CreatePorts(JasonNodePorts ports) { }
        public virtual void RemovePorts(JasonNodePorts ports) { }
        public virtual void CreateChildNodes(JasonGrafView graph) { }
        public virtual void AttachNode(JasonNodeView node) { }
        public virtual void DetachNode(JasonNodeView node) { }

        protected void AddBasicControls()
        {
            contentContainer.style.flexDirection = new StyleEnum<FlexDirection> { value = FlexDirection.Row };
            AddRemoveButton();
            AddNameField();
        }

        protected void AddRemoveButton()
        {
            var button = new Button(() => Owner.RemoveProperty(Property))
            {
                text = "X"
            };
            contentContainer.Add(button);
        }

        protected void AddNameField()
        {
            var textField = new TextField()
            {
                name = string.Empty,
                value = Property.Name
            };
            textField.RegisterValueChangedCallback(evt => Property.Name = evt.newValue);
            contentContainer.Add(textField);
        }
    }
}