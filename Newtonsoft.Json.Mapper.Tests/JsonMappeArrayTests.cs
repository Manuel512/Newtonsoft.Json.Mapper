using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using static Newtonsoft.Json.Mapper.Tests.JsonMapperArrayTestsUtils;
using Newtonsoft.Json.Mapper.Tests.Utils;
using System.Linq;
using System.Text;
using Xunit;

namespace Newtonsoft.Json.Mapper.Tests
{
    public class JsonMappeArrayTests
    {
        [Fact]
        public void MapToDictionary_ValidMappingArray_ReturnsMappedCollectionDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _mapRule;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, rules);

            //Assert
            Assert.NotEmpty(resultDict["Products"]);
        }

        [Fact]
        public void MapToDictionary_InvalidMappingArray_ReturnsEmptyMappedCollectionDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> wrongrules = _wrongMapRule;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, wrongrules);

            //Assert
            Assert.Empty(resultDict["Products"]);
        }

        [Fact]
        public void MapToDictionary_ValidMappingArrayWithMappingProperties_ReturnsDeepMappedCollectionDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _deepMapRule;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, rules);

            //Assert
            Assert.NotEmpty(resultDict["Products"]);
            Assert.All(resultDict["Products"].Values<string>("Name").ToList(), x => Assert.Contains(x, _productNames));
            Assert.All(resultDict["Products"].Values<DateTime>("ReleaseDate").ToList(), x => Assert.Equal(_releaseDate, x));
        }

        [Fact]
        public void MapToDictionary_InvalidMappingArrayWithMappingProperties_ReturnsDeepEmptyMappedCollectionDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> wrongRules = _wrongDeepMapRule;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, wrongRules);

            //Assert
            Assert.NotEmpty(resultDict["Products"]);
            Assert.All(resultDict["Products"].Values<string>("Name").ToList(), x => Assert.Null(x));
            Assert.All(resultDict["Products"].Values<DateTime?>("ReleaseDate").ToList(), x => Assert.Null(x));
        }

        [Fact]
        public void MapToDictionary_ValidMappingArrayObjectProperty_ReturnsDeepMappedCollectionDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _deepObjectMapRule;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, rules);

            //Assert
            Assert.NotNull(resultDict["Products"]);
            Assert.NotEmpty(resultDict["Products"]);
            Assert.All(resultDict["Products"].Values<string>().ToList(), x => Assert.Contains(x, _productNames));
        }

        [Fact]
        public void MapToDictionary_InvalidMappingArrayObjectProperty_ReturnsDeepEmptyMappedCollectionDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _wrongDeepObjectMapRule;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, rules);

            //Assert
            Assert.NotNull(resultDict["Products"]);
            Assert.Empty(resultDict["Products"]);
        }

        [Fact]
        public void MapToJsonString_ValidMappingArray_ReturnsMappedCollectionJsonString()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _mapRule;

            //Act
            string result = JsonMapper.MapToJsonString(jsonString, rules);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(_mappedDummyJsonString, result);
        }

        [Fact]
        public void MapToJsonString_InvalidMappingArray_ReturnsEmptyMappedCollectionJsonString()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> wrongRules = _wrongMapRule;

            //Act
            string result = JsonMapper.MapToJsonString(jsonString, wrongRules);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(_emptyMappedDummyJsonString, result);
        }

        [Fact]
        public void MapToJsonString_ValidMappingArrayWithMappingProperties_ReturnsDeepMappedCollectionJsonString()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _deepMapRule;

            //Act
            var result = JsonMapper.MapToJsonString(jsonString, rules);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(_customMappedDummyJsonString, result);
        }

        [Fact]
        public void MapToJsonString_InvalidMappingArrayWithMappingProperties_ReturnsDeepEmptyMappedCollectionJsonString()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> wrongRules = _wrongDeepMapRule;

            //Act
            var result = JsonMapper.MapToJsonString(jsonString, wrongRules);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(_customNullMappedDummyJsonString, result);
        }

        [Fact]
        public void MapTo_ValidMappingArray_ReturnsMappedCollectionType()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _mapRule;

            //Act
            DummyObjectWithAttributes result = JsonMapper.MapTo<DummyObjectWithAttributes>(jsonString, rules);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Products);
            Assert.All(result.Products, x => {
                Assert.NotNull(x.Name);
                Assert.Contains(x.Name, _productNames);
                Assert.NotNull(x.ReleaseDate);
                Assert.Equal(_releaseDate, x.ReleaseDate);
            });
        }

        [Fact]
        public void MapTo_InvalidMappingArray_ReturnsEmptyMappedCollectionType()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> wrongrules = _wrongMapRule;

            //Act
            DummyObjectWithAttributes result = JsonMapper.MapTo<DummyObjectWithAttributes>(jsonString, wrongrules);

            //Assert
            Assert.NotNull(result);
            Assert.Empty(result.Products);
        }

        [Fact]
        public void MapTo_ValidMappingArrayWithMappingProperties_ReturnsDeepMappedCollectionType()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _deepMapRule;

            //Act
            DummyObjects result = JsonMapper.MapTo<DummyObjects>(jsonString, rules);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Products);
            Assert.All(result.Products, x => {
                Assert.NotNull(x.Name);
                Assert.Contains(x.Name, _productNames);
                Assert.NotNull(x.ReleaseDate);
                Assert.Equal(_releaseDate, x.ReleaseDate);
            });
        }

        [Fact]
        public void MapTo_InvalidMappingArrayWithMappingProperties_ReturnsDeepEmptyMappedCollectionType()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> wrongRules = _wrongDeepMapRule;

            //Act
            DummyObjects result = JsonMapper.MapTo<DummyObjects>(jsonString, wrongRules);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Products);
            Assert.All(result.Products, x => {
                Assert.Null(x.Name);
                Assert.Null(x.ReleaseDate);
            });
        }
    }
}
