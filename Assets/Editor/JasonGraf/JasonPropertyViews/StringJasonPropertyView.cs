using JasonGraf.JasonProperty;

namespace JasonGraf.JasonPropertyViews
{
    public class StringJasonPropertyView : BaseJasonPropertyView
    {
        public new StringJasonProperty Property;

        public StringJasonPropertyView(StringJasonProperty property, JasonNode jasonNode)
            : base(property, jasonNode)
        {
            Property = property;
        }
    }
}