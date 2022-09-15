using JasonGraf.JasonProperty;
using UnityEngine.UIElements;

namespace JasonGraf.JasonPropertyViews
{
    public class BaseJasonPropertyView : VisualElement
    {
        public BaseJasonProperty Property;

        public BaseJasonPropertyView(BaseJasonProperty property)
        {
            Property = property;
        }

        public virtual void CreateChildNodes(JasonGrafView graph, JasonNodePorts ports)
        {
        }

        public virtual void AttachNode(JasonNodeView node)
        {
        }

        public virtual void DetachNode(JasonNodeView node)
        {
        }
    }
}