using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.Mapper.Tests
{
    public static class JsonMapperArrayTestsUtils
    {
        public static readonly List<string> _productNames = new List<string> { "some name value", "some name value2" };
        public static readonly string _releaseDateStr = "2021-04-27T23:10:35.048811Z";
        public static readonly DateTime _releaseDate = DateTime.Parse(_releaseDateStr).ToUniversalTime();
        public static readonly string _getDummyJsonString = "{\"products\":[" +
                                                                "{\"name\":\"" + _productNames[0] + "\",\"release_date\":\"" + _releaseDateStr + "\"}," +
                                                                "{\"name\":\"" + _productNames[1] + "\",\"release_date\":\"" + _releaseDateStr + "\"}" +
                                                             "]}";

        public static readonly string _mappedDummyJsonString = "{\"Products\":[" +
                                                                    "{\"name\":\"" + _productNames[0] + "\",\"release_date\":\"" + _releaseDateStr + "\"}," +
                                                                    "{\"name\":\"" + _productNames[1] + "\",\"release_date\":\"" + _releaseDateStr + "\"}" +
                                                                "]}";
        public static readonly string _emptyMappedDummyJsonString = "{\"Products\":[]}";

        public static readonly string _customMappedDummyJsonString = "{\"Products\":[" +
                                                                         "{\"Name\":\"" + _productNames[0] + "\",\"ReleaseDate\":\"" + _releaseDateStr + "\"}," +
                                                                         "{\"Name\":\"" + _productNames[1] + "\",\"ReleaseDate\":\"" + _releaseDateStr + "\"}" +
                                                                      "]}";
        public static readonly string _customNullMappedDummyJsonString = "{\"Products\":[" +
                                                                             "{\"Name\":null,\"ReleaseDate\":null}," +
                                                                             "{\"Name\":null,\"ReleaseDate\":null}" +
                                                                          "]}";

        public static readonly List<MappingRule> _mapRule = new List<MappingRule> { new MappingRule("products[*]", "Products", "Array") };
        public static readonly List<MappingRule> _wrongMapRule = new List<MappingRule> { new MappingRule("productsArray[*]", "Products", "Array") };

        public static readonly List<MappingRule> _deepMapRule = new List<MappingRule>
            {
                new MappingRule("products[*]", "Products", "Array")
                    .AddMapProperty("name", "Name")
                    .AddMapProperty("release_date", "ReleaseDate")
            };
        public static readonly List<MappingRule> _wrongDeepMapRule = new List<MappingRule>
            {
                new MappingRule("products[*]", "Products", "Array")
                    .AddMapProperty("names", "Name")
                    .AddMapProperty("release_dates", "ReleaseDate")
            };
        public static readonly List<MappingRule> _deepObjectMapRule = new List<MappingRule>
            {
                new MappingRule("products[*].name", "Products", "Array")
            };
        public static readonly List<MappingRule> _wrongDeepObjectMapRule = new List<MappingRule>
            {
                new MappingRule("products[*].name1", "Products", "Array")
            };
    }
}
