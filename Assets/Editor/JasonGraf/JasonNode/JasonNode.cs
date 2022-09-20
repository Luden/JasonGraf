using System;
using System.Collections.Generic;
using System.Linq;
using JasonGraf.JasonProperty;
using UnityEngine;

namespace JasonGraf
{
    public abstract class JasonNode
    {
        public event Action<BaseJasonProperty> PropertyRemoved;
        public event Action<BaseJasonProperty> PropertyAdded;

        public string Id;
        public string Type;
        public string MetaType;
        public Vector2 Position;
        public List<BaseJasonProperty> Properties = new List<BaseJasonProperty>();

        public void Parse(IDictionary<string, object> data)
        {
            Properties.Clear();
            foreach (var pair in data)
            {
                var property = JasonPropertyFactory.Create(data, pair.Key);
                Properties.Add(property);
            }
            LoadPosition();
        }

        public IDictionary<string, object> Serialize()
        {
            var result = new Dictionary<string, object>();
            foreach (var property in Properties)
                result[property.Name] = property.Serialize();
            CommitPosition(result);
            return result;
        }

        public void AddProperty(BaseJasonProperty property)
        {
            Properties.Add(property);
            PropertyAdded?.Invoke(property);
        }

        public void RemoveProperty(BaseJasonProperty property)
        {
            Properties.Remove(property);
            PropertyRemoved?.Invoke(property);
        }

        private void LoadPosition()
        {
            var posProperty = Properties.FirstOrDefault(x => x.Name == "_pos") as FloatListJasonProperty;
            if (posProperty != null)
            {
                Properties.Remove(posProperty);
                Position = new Vector2(posProperty.Value[0], posProperty.Value[1]);
            }
        }

        private void CommitPosition(IDictionary<string, object> data)
        {
            data["_pos"] = new int[] { (int)Position.x, (int)Position.y };
        }
    }
}