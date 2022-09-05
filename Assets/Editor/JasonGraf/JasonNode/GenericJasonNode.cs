using JasonGraf.JasonProperty;

namespace JasonGraf
{
    public class GenericJasonNode : JasonNode
    {
        public override void Parse()
        {
            Properties.Clear();
            foreach (var pair in Data)
            {
                var property = JasonPropertyFactory.Create(Data, pair.Key);
                Properties[pair.Key] = property;
            }
        }
    }
}