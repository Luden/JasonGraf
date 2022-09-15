using JasonGraf.JasonProperty;

namespace JasonGraf.JasonPropertyViews
{
    public class FloatJasonPropertyView : BaseJasonPropertyView
    {
        public new FloatJasonProperty Property;

        public FloatJasonPropertyView(FloatJasonProperty property)
            : base(property)
        {
            Property = property;
        }
    }
}