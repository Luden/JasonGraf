using JasonGraf.JasonProperty;

namespace JasonGraf.JasonPropertyViews
{
    public class FloatListJasonPropertyView : BaseJasonPropertyView
    {
        public new FloatListJasonProperty Property;

        public FloatListJasonPropertyView(FloatListJasonProperty property, JasonNode jasonNode)
            : base(property, jasonNode)
        {
            Property = property;
        }
    }
}