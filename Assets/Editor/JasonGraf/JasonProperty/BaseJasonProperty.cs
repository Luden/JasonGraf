namespace JasonGraf.JasonProperty
{
    public abstract class BaseJasonProperty
    {
        public abstract JasonPropertyType Type { get; }

        public string Name;

        public abstract void Parse(object value);

        public abstract object Serialize();
    }
}