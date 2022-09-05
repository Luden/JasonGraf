using System.Collections.Generic;
using JasonGraf.JasonProperty;

namespace JasonGraf
{
    public abstract class JasonNode
    {
        public string Id;
        public string Type;
        public string MetaType;
        public IDictionary<string, object> Data;
        public IDictionary<string, BaseJasonProperty> Properties = new Dictionary<string, BaseJasonProperty>();

        public void Parse(IDictionary<string, object> data)
        {
            Data = data;
            Parse();
        }

        public abstract void Parse();

        public IDictionary<string, object> Serialize()
        {
            foreach (var property in Properties)
            {
                property.Value.Commit();
            }
            return Data;
        }
    }
}