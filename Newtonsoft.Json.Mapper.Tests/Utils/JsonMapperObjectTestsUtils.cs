using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.Mapper.Tests
{
    public static class JsonMapperObjectTestsUtils
    {
        public static readonly string _productName = "some name value";
        public static readonly string _releaseDateStr = "2021-04-27T23:10:35.048811Z";
        public static readonly DateTime _releaseDate = DateTime.Parse(_releaseDateStr).ToUniversalTime();
        public static readonly string _getDummyJsonString = "{\"product\":{\"name\":\"" + _productName + "\",\"release_date\":\"" + _releaseDateStr + "\"}}";

        public static readonly string _mappedDummyJsonString = "{\"Product\":{\"name\":\"" + _productName + "\",\"release_date\":\"" + _releaseDateStr + "\"}}";
        public static readonly string _nullMappedDummyJsonString = "{\"Product\":null}";

        public static readonly string _customMappedDummyJsonString = "{\"Product\":{\"Name\":\"" + _productName + "\",\"ReleaseDate\":\"" + _releaseDateStr + "\"}}";
        public static readonly string _customNullMappedDummyJsonString = "{\"Product\":{\"Name\":null,\"ReleaseDate\":null}}";

        public static readonly List<MappingRule> _mapRule = new List<MappingRule> { new MappingRule("product", "Product", "Object") };
        public static readonly List<MappingRule> _wrongMapRule = new List<MappingRule> { new MappingRule("products", "Product", "Object") };

        public static readonly List<MappingRule> _deepMapRule = new List<MappingRule>
            {
                new MappingRule("product", "Product", "Object")
                    .AddMapProperty("name", "Name")
                    .AddMapProperty("release_date", "ReleaseDate")
            };
        public static readonly List<MappingRule> _wrongDeepMapRule = new List<MappingRule>
            {
                new MappingRule("product", "Product", "Object")
                    .AddMapProperty("names", "Name")
                    .AddMapProperty("release_dates", "ReleaseDate")
            };

    }
}
