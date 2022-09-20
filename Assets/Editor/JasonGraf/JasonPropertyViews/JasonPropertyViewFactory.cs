using System;
using JasonGraf.JasonProperty;

namespace JasonGraf.JasonPropertyViews
{
    public class JasonPropertyViewFactory
    {
        public static BaseJasonPropertyView Create(BaseJasonProperty node, JasonNode owner)
        {
            if (node is StringJasonProperty stringJasonProperty) return new StringJasonPropertyView(stringJasonProperty, owner);
            if (node is StringListJasonProperty stringListJasonProperty) return new StringListJasonPropertyView(stringListJasonProperty, owner);
            if (node is BoolJasonProperty boolJasonProperty) return new BoolJasonPropertyView(boolJasonProperty, owner);
            if (node is FloatJasonProperty floatJasonProperty) return new FloatJasonPropertyView(floatJasonProperty, owner);
            if (node is FloatListJasonProperty floatListJasonProperty) return new FloatListJasonPropertyView(floatListJasonProperty, owner);
            if (node is NodeJasonProperty nodeJasonProperty) return new NodeJasonPropertyView(nodeJasonProperty, owner);
            if (node is NodeListJasonProperty nodeListJasonProperty) return new NodeListJasonPropertyView(nodeListJasonProperty, owner);
            throw new ApplicationException();
        }
    }
}