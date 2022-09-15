using System;
using JasonGraf.JasonProperty;

namespace JasonGraf.JasonPropertyViews
{
    public class JasonPropertyViewFactory
    {
        public static BaseJasonPropertyView Create(BaseJasonProperty node)
        {
            if (node is StringJasonProperty stringJasonProperty) return new StringJasonPropertyView(stringJasonProperty);
            if (node is StringListJasonProperty stringListJasonProperty) return new StringListJasonPropertyView(stringListJasonProperty);
            if (node is BoolJasonProperty boolJasonProperty) return new BoolJasonPropertyView(boolJasonProperty);
            if (node is FloatJasonProperty floatJasonProperty) return new FloatJasonPropertyView(floatJasonProperty);
            if (node is FloatListJasonProperty floatListJasonProperty) return new FloatListJasonPropertyView(floatListJasonProperty);
            if (node is NodeJasonProperty nodeJasonProperty) return new NodeJasonPropertyView(nodeJasonProperty);
            if (node is NodeListJasonProperty nodeListJasonProperty) return new NodeListJasonPropertyView(nodeListJasonProperty);
            throw new ApplicationException();
        }
    }
}