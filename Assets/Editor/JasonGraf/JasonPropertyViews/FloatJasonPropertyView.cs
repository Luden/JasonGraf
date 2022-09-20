using JasonGraf.JasonProperty;

namespace JasonGraf.JasonPropertyViews
{
    public class FloatJasonPropertyView : BaseJasonPropertyView
    {
        public new FloatJasonProperty Property;

        public FloatJasonPropertyView(FloatJasonProperty property, JasonNode jasonNode)
            : base(property, jasonNode)
        {
            Property = property;
        }
    }
}