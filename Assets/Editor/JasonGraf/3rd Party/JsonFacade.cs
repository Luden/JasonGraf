using System.Collections.Generic;

namespace JasonGraf
{
    public class JsonFacade
    {
        public static string JsonToString(IDictionary<string, object> json)
        {
            return Json.Serialize(json);
        }

        public static IDictionary<string, object> StringToJson(string text)
        {
            return (IDictionary<string, object>)Json.Deserialize(text);
        }
    }
}