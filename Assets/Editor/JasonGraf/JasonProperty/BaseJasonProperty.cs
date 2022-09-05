using System.Collections.Generic;

namespace JasonGraf.JasonProperty
{
    public abstract class BaseJasonProperty
    {
        public abstract JasonPropertyType Type { get; }

        public string Name;

        protected IDictionary<string, object> ParentNode;

        public void Parse(IDictionary<string, object> parentNode, string name)
        {
            Name = name;
            ParentNode = parentNode;
            Parse();
        }

        public abstract void Parse();

        public abstract void Commit();
    }
}