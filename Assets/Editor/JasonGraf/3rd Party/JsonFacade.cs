using System;
using System.Collections.Generic;

namespace JasonGraf
{
    public class JsonFacade
    {
        public static string JsonToString(IDictionary<string, object> json)
        {
            return JsonBeautifier.FormatJson(Json.Serialize(json));
        }

        public static IDictionary<string, object> StringToJson(string text)
        {
            return (IDictionary<string, object>)Json.Deserialize(text);
        }

        public static bool IsJson(string text)
        {
            try
            {
                var json = StringToJson(text);
                return json.Count > 0;
            }
            catch (Exception e)
            {
            }
            return false;
        }
    }
}