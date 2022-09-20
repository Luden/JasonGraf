using System;
using System.Collections.Generic;
using System.Linq;

namespace JasonGraf.JasonProperty
{
    public static class JasonPropertyFactory
    {
        public static BaseJasonProperty Create(IDictionary<string, object> parent, string name)
        {
            var objectValue = parent[name];
            var jasonProperty = Create(objectValue);
            jasonProperty.Name = name;
            jasonProperty.Parse(parent[name]);
            return jasonProperty;
        }

        private static BaseJasonProperty Create(object value)
        {
            if (value is string) return new StringJasonProperty();
            if (value is bool) return new BoolJasonProperty();
            if (value is float) return new FloatJasonProperty();
            if (value is int) return new FloatJasonProperty();
            if (value is long) return new FloatJasonProperty();
            if (value is double) return new FloatJasonProperty();
            if (value is List<object> listValue)
            {
                var anyValue = listValue.FirstOrDefault();
                if (anyValue is int) return new FloatListJasonProperty();
                if (anyValue is long) return new FloatListJasonProperty();
                if (anyValue is float) return new FloatListJasonProperty();
                if (anyValue is double) return new FloatListJasonProperty();
                if (anyValue is string) return new StringListJasonProperty();
                if (anyValue is IDictionary<string, object>) return new NodeListJasonProperty();
                if (anyValue == null) return new NodeListJasonProperty();
                throw new ApplicationException();
            }
            if (value is IDictionary<string, object>) return new NodeJasonProperty();
            throw new ApplicationException();
        }
    }
}