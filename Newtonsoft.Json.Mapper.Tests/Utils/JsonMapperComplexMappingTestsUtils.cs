using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.Mapper.Tests
{
    public static class JsonMapperComplexMappingTestsUtils
    {
        public  static readonly string _productName = "some name value";
        public  static readonly string _releaseDateStr = "2021-04-27T23:10:35.048811Z";
        public  static readonly DateTime _releaseDate = DateTime.Parse(_releaseDateStr).ToUniversalTime();
        public  static readonly string _modelName = "some model value";
        public  static readonly decimal _price = 62;
        public  static readonly string _getDummyJsonString = "{" +
                                                                "\"product\":{" +
                                                                    "\"name\":\"" + _productName + "\"," +
                                                                    "\"release_date\":\"" + _releaseDateStr + "\"" +
                                                                "}," +
                                                                "\"productDetails\":{" +
                                                                    "\"model\":\"" + _modelName + "\"," +
                                                                    "\"price\":" + _price +
                                                                "}" +
                                                             "}";

        public  static readonly string _mappedDummyJsonString = "{" +
                                                                    "\"Product\":{" +
                                                                        "\"Name\":\"" + _productName + "\"," +
                                                                        "\"ReleaseDate\":\"" + _releaseDateStr + "\"," +
                                                                        "\"Model\":\"" + _modelName + "\"," +
                                                                        "\"Price\":" + _price +
                                                                    "}" +
                                                                 "}";
        public  static readonly string _nullMappedDummyJsonString = "{\"Product\":null}";

        public  static readonly string _customMappedDummyJsonString = "{\"Product\":{\"Name\":\"" + _productName + "\",\"ReleaseDate\":\"" + _releaseDateStr + "\"}}";
        public  static readonly string _customNullMappedDummyJsonString = "{\"Product\":{\"Name\":null,\"ReleaseDate\":null}}";

        public  static readonly List<MappingRule> _mapRuleSameDestination = new List<MappingRule> {
            new MappingRule("product", "Product", "Object"),
            new MappingRule("productDetails", "Product", "Object")
        };
        public  static readonly List<MappingRule> _wrongMapRuleSameDestination1 = new List<MappingRule> {
            new MappingRule("product", "Product", "Object"),
            new MappingRule("productDetails2", "Product", "Object")
        };

        public  static readonly List<MappingRule> _wrongMapRuleSameDestination2 = new List<MappingRule> {
            new MappingRule("product1", "Product", "Object"),
            new MappingRule("productDetails", "Product", "Object")
        };

        public  static readonly List<MappingRule> _singleMapRule = new List<MappingRule> {
            new MappingRule("product.name", "ProductName", "Value"),
            new MappingRule("productDetails.price", "ProductPrice", "Value")
        };

        public  static readonly List<MappingRule> _wrongSingleMapRule = new List<MappingRule> {
            new MappingRule("product.name1", "ProductName", "Value"),
            new MappingRule("productDetails.price2", "ProductPrice", "Value")
        };

        public  static readonly List<MappingRule> _complexMapRuleSameDestination = new List<MappingRule> {
            new MappingRule("product.name", "Product", "Property"),
            new MappingRule("productDetails.price", "Product", "Property")
        };

        public  static readonly List<MappingRule> _wrongComplexMapRuleSameDestination1 = new List<MappingRule> {
            new MappingRule("product.name", "Product", "Property"),
            new MappingRule("productDetails.price1", "Product", "Property")
        };

        public  static readonly List<MappingRule> _wrongComplexMapRuleSameDestination2 = new List<MappingRule> {
            new MappingRule("product.name1", "Product", "Property"),
            new MappingRule("productDetails.price", "Product", "Property")
        };

        public  static readonly List<MappingRule> _complexDeepMapRuleSameDestination = new List<MappingRule> {
            new MappingRule("product.name", "Product", "Property")
                .AddMapProperty("name", "Name"),
            new MappingRule("productDetails.price", "Product", "Property")
                .AddMapProperty("price", "Price")
        };

        public  static readonly List<MappingRule> _wrongComplexDeepMapRuleSameDestination1 = new List<MappingRule> {
            new MappingRule("product.name", "Product", "Property")
                .AddMapProperty("name", "Name"),
            new MappingRule("productDetails.price1", "Product", "Property")
                .AddMapProperty("price", "Price")
        };

        public  static readonly List<MappingRule> _wrongComplexDeepMapRuleSameDestination2 = new List<MappingRule> {
            new MappingRule("product.name", "Product", "Property")
                .AddMapProperty("name", "Name"),
            new MappingRule("productDetails.price", "Product", "Property")
                .AddMapProperty("price1", "Price")
        };

        public  static readonly List<MappingRule> _wrongComplexDeepMapRuleSameDestination3 = new List<MappingRule> {
            new MappingRule("product.name1", "Product", "Property")
                .AddMapProperty("name", "Name"),
            new MappingRule("productDetails.price", "Product", "Property")
                .AddMapProperty("price", "Price")
        };

        public  static readonly List<MappingRule> _wrongComplexDeepMapRuleSameDestination4 = new List<MappingRule> {
            new MappingRule("product.name", "Product", "Property")
                .AddMapProperty("name1", "Name"),
            new MappingRule("productDetails.price", "Product", "Property")
                .AddMapProperty("price", "Price")
        };

        public  static readonly List<MappingRule> _deepMapRuleSameDestination = new List<MappingRule> {
            new MappingRule("product", "Product", "Object")
            .AddMapProperty("name", "Name")
            .AddMapProperty("release_date", "ReleaseDate"),
            new MappingRule("productDetails", "Product", "Object")
            .AddMapProperty("model", "Model")
            .AddMapProperty("price", "Price")
        };

        public  static readonly List<MappingRule> _wrongdeepMapRuleSameDestination1 = new List<MappingRule> {
            new MappingRule("product", "Product", "Object")
            .AddMapProperty("name", "Name")
            .AddMapProperty("release_date", "ReleaseDate"),
            new MappingRule("productDetails", "Product", "Object")
            .AddMapProperty("model1", "Model")
            .AddMapProperty("price2", "Price")
        };

        public  static readonly List<MappingRule> _wrongdeepMapRuleSameDestination2 = new List<MappingRule> {
            new MappingRule("product", "Product", "Object")
            .AddMapProperty("name1", "Name")
            .AddMapProperty("release_date2", "ReleaseDate"),
            new MappingRule("productDetails", "Product", "Object")
            .AddMapProperty("model", "Model")
            .AddMapProperty("price", "Price")
        };
    }
}
