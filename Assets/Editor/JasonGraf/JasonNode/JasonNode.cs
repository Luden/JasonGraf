using System.Collections.Generic;
using JasonGraf.JasonProperty;
using UnityEngine;

namespace JasonGraf
{
    public abstract class JasonNode
    {
        public string Id;
        public string Type;
        public string MetaType;
        public Vector2 Position;
        public IDictionary<string, object> Data;
        public IDictionary<string, BaseJasonProperty> Properties = new Dictionary<string, BaseJasonProperty>();

        public void Parse(IDictionary<string, object> data)
        {
            Data = data;
            Parse();
        }

        public virtual void Parse()
        {
            Properties.Clear();
            foreach (var pair in Data)
            {
                var property = JasonPropertyFactory.Create(Data, pair.Key);
                Properties[pair.Key] = property;
            }
            LoadPosition();
        }

        public IDictionary<string, object> Serialize()
        {
            foreach (var property in Properties)
            {
                property.Value.Commit();
            }
            CommitPosition();
            return Data;
        }

        private void LoadPosition()
        {
            if (Properties.TryGetValue("_pos", out var posProp) && posProp is FloatListJasonProperty floatProp)
            {
                Properties.Remove("_pos");
                Position = new Vector2(floatProp.Value[0], floatProp.Value[1]);
            }
        }

        private void CommitPosition()
        {
            Data["_pos"] = new int[] { (int)Position.x, (int)Position.y };
        }
    }
}