using JasonGraf.JasonProperty;

namespace JasonGraf.JasonPropertyViews
{
    public class BoolJasonPropertyView : BaseJasonPropertyView
    {
        public new BoolJasonProperty Property;

        public BoolJasonPropertyView(BoolJasonProperty property)
            : base(property)
        {
            Property = property;
        }
    }
}