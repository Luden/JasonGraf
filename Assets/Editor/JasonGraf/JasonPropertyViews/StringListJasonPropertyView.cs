using JasonGraf.JasonProperty;

namespace JasonGraf.JasonPropertyViews
{
    public class StringListJasonPropertyView : BaseJasonPropertyView
    {
        public new StringListJasonProperty Property;

        public StringListJasonPropertyView(StringListJasonProperty property)
            : base(property)
        {
            Property = property;
        }
    }
}