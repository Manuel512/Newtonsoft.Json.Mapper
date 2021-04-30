using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using static Newtonsoft.Json.Mapper.Tests.JsonMapperObjectTestsUtils;
using Xunit;

namespace Newtonsoft.Json.Mapper.Tests
{
    public class JsonMapperObjectTests
    {
        [Fact]
        public void MapToDictionary_ValidMappingObject_ReturnsMappedDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _mapRule;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, rules);

            //Assert
            Assert.NotNull(resultDict["Product"]);
        }

        [Fact]
        public void MapToDictionary_InvalidMappingObject_ReturnsNullMappedDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> wrongrules = _wrongMapRule;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, wrongrules);

            //Assert
            Assert.Null(resultDict["Product"]);
        }

        [Fact]
        public void MapToDictionary_ValidMappingObjectWithMappingProperties_ReturnsDeepMappedDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _deepMapRule;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, rules);

            //Assert
            Assert.NotNull(resultDict["Product"]);
            Assert.Equal(_productName, resultDict["Product"]["Name"]);
            Assert.Equal(_releaseDateStr, resultDict["Product"]["ReleaseDate"]);
        }

        [Fact]
        public void MapToDictionary_InvalidMappingObjectWithMappingProperties_ReturnsDeepNullMappedDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> wrongRules = _wrongDeepMapRule;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, wrongRules);

            //Assert
            Assert.NotNull(resultDict["Product"]);
            Assert.Null(resultDict["Product"].Value<JValue>("Name").Value);
            Assert.Null(resultDict["Product"].Value<JValue>("ReleaseDate").Value);
        }

        [Fact]
        public void MapToJsonString_ValidMappingObject_ReturnsMappedJsonString()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _mapRule;

            //Act
            string result = JsonMapper.MapToJsonString(jsonString, rules);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_mappedDummyJsonString, result);
        }

        [Fact]
        public void MapToJsonString_InvalidMappingObject_ReturnsNullMappedJsonString()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> wrongRules = _wrongMapRule;

            //Act
            string result = JsonMapper.MapToJsonString(jsonString, wrongRules);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_nullMappedDummyJsonString, result);
        }

        [Fact]
        public void MapToJsonString_ValidMappingObjectWithMappingProperties_ReturnsDeepMappedJsonString()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _deepMapRule;

            //Act
            var result = JsonMapper.MapToJsonString(jsonString, rules);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_customMappedDummyJsonString, result);
        }

        [Fact]
        public void MapToJsonString_InvalidMappingObjectWithMappingProperties_ReturnsDeepNullMappedJsonString()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> wrongRules = _wrongDeepMapRule;

            //Act
            var result = JsonMapper.MapToJsonString(jsonString, wrongRules);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_customNullMappedDummyJsonString, result);
        }

        [Fact]
        public void MapTo_ValidMappingObject_ReturnsMappedType()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _mapRule;

            //Act
            DummyObjectWithAttributes result = JsonMapper.MapTo<DummyObjectWithAttributes>(jsonString, rules);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Product);
            Assert.Equal(_productName, result.Product.Name);
            Assert.Equal(_releaseDate, result.Product.ReleaseDate);
        }

        [Fact]
        public void MapTo_InvalidMappingObject_ReturnsNullMappedType()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> wrongrules = _wrongMapRule;

            //Act
            DummyObjectWithAttributes result = JsonMapper.MapTo<DummyObjectWithAttributes>(jsonString, wrongrules);

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.Product);
        }

        [Fact]
        public void MapTo_ValidMappingObjectWithMappingProperties_ReturnsDeepMappedType()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _deepMapRule;

            //Act
            DummyObject result = JsonMapper.MapTo<DummyObject>(jsonString, rules);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Product);
            Assert.Equal(_productName, result.Product.Name);
            Assert.Equal(_releaseDate, result.Product.ReleaseDate);
        }

        [Fact]
        public void MapTo_InvalidMappingObjectWithMappingProperties_ReturnsDeepNullMappedType()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> wrongRules = _wrongDeepMapRule;

            //Act
            DummyObject result = JsonMapper.MapTo<DummyObject>(jsonString, wrongRules);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Product);
            Assert.Null(result.Product.Name);
            Assert.Null(result.Product.ReleaseDate);
        }

        private class DummyObjectWithAttributes
        {
            public DummyProductWithAttributes Product { get; set; }
        }

        private class DummyProductWithAttributes
        {
            public string Name { get; set; }
            
            [JsonProperty("release_date")]
            public DateTime ReleaseDate { get; set; }
        }

        private class DummyObject
        {
            public DummyProduct Product { get; set; }
        }

        private class DummyProduct
        {
            public string Name { get; set; }
            public DateTime? ReleaseDate { get; set; }
        }
    }
}
