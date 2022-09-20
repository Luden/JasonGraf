using JasonGraf.JasonProperty;
using UnityEngine.UIElements;

namespace JasonGraf.JasonPropertyViews
{
    public class BoolJasonPropertyView : BaseJasonPropertyView
    {
        public new BoolJasonProperty Property;
        private readonly Toggle _toggle;

        public BoolJasonPropertyView(BoolJasonProperty property, JasonNode jasonNode)
            : base(property, jasonNode)
        {
            Property = property;
            AddBasicControls();
            _toggle = new Toggle()
            {
                value = Property.Value
            };
            _toggle.RegisterCallback<ChangeEvent<bool>>(OnToggleChange);
            contentContainer.Add(_toggle);
        }

        private void OnToggleChange(ChangeEvent<bool> change)
        {
            Property.Value = change.newValue;
        }
    }
}