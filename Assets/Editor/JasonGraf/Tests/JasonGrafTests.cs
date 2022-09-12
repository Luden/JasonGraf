using System.Collections.Generic;
using NUnit.Framework;

namespace JasonGraf.Tests
{
    public class JasonGrafTests
    {
        private string _testStr = @"{
  ""node_1"": {
    ""int"": 1,
    ""float"": 2.3,
    ""bool"": true,
    ""string"": ""test_string"",
    ""sub_node"": {
      ""string_2"": ""test_2"",
      ""bool_2"": false
    },
    ""int_list"": [
      1,
      2,
      3
    ],
    ""float_list"": [
      1.2,
      2.3,
      3.4
    ],
    ""string_list"": [
      ""foo"",
      ""bar"",
      ""baz""
    ],
    ""node_list"": [
      {
        ""string_3"": ""test_3""
      },
      {
        ""bool_3"": true
      }
    ]
  }
}";

        [Test]
        public void JsonFacadeWorks()
        {
          var json = JsonFacade.StringToJson(_testStr);
          var text = JsonFacade.JsonToString(json);
          var root = (IDictionary<string, object>)json["node_1"];
          Assert.IsTrue((string)root["string"] == "test_string");
          Assert.IsTrue(text.Contains("test_string"));
        }

        [Test]
        public void ParseAndSerializeTest()
        {
          var json = JsonFacade.StringToJson(_testStr);
          var node = JasonNodeFactory.Create("", json);
          var newJson = node.Serialize();
          var text = JsonFacade.JsonToString(json);
          var newText = JsonFacade.JsonToString(newJson);
          Assert.IsTrue(text == newText);
        }
    }
}