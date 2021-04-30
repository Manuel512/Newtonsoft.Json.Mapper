using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using static Newtonsoft.Json.Mapper.Tests.JsonMapperComplexMappingTestsUtils;
using System.Text;
using Xunit;

namespace Newtonsoft.Json.Mapper.Tests
{
    public class JsonMapperComplexMappingTests
    {
        [Fact]
        public void MapToDictionary_ValidMappingSameDestinationObject_ReturnsMergedMappedDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _mapRuleSameDestination;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, rules);

            //Assert
            Assert.NotNull(resultDict["Product"]);
            Assert.NotNull(resultDict["Product"]["name"]);
            Assert.NotNull(resultDict["Product"]["release_date"]);
            Assert.NotNull(resultDict["Product"]["model"]);
            Assert.NotNull(resultDict["Product"]["price"]);
        }

        [Fact]
        public void MapToDictionary_SomeInvalidMappingSameDestinationObject_ReturnsSomeNullMergedMappedDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules1 = _wrongMapRuleSameDestination1;
            List<MappingRule> rules2 = _wrongMapRuleSameDestination2;

            //Act
            var resultDict1 = JsonMapper.MapToDictionary(jsonString, rules1);
            var resultDict2 = JsonMapper.MapToDictionary(jsonString, rules2);

            //Assert
            Assert.NotNull(resultDict1["Product"]);
            Assert.NotNull(resultDict1["Product"]["name"]);
            Assert.NotNull(resultDict1["Product"]["release_date"]);
            Assert.Null(resultDict1["Product"]["model"]);
            Assert.Null(resultDict1["Product"]["price"]);

            Assert.NotNull(resultDict2["Product"]);
            Assert.Null(resultDict2["Product"]["name"]);
            Assert.Null(resultDict2["Product"]["release_date"]);
            Assert.NotNull(resultDict2["Product"]["model"]);
            Assert.NotNull(resultDict2["Product"]["price"]);
        }

        [Fact]
        public void MapToDictionary_ValidMappingSameDestinationObjectWithMappingProperties_ReturnsDeepMergedMappedDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _deepMapRuleSameDestination;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, rules);

            //Assert
            Assert.NotNull(resultDict["Product"]);
            Assert.Equal(_productName, resultDict["Product"]["Name"]);
            Assert.Equal(_releaseDateStr, resultDict["Product"]["ReleaseDate"]);
            Assert.Equal(_modelName, resultDict["Product"]["Model"]);
            Assert.Equal(_price, resultDict["Product"]["Price"]);
        }

        [Fact]
        public void MapToDictionary_SomeInvalidMappingSameDestinationObjectWithMappingProperties_ReturnsSomeNullDeepMergedMappedDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules1 = _wrongdeepMapRuleSameDestination1;
            List<MappingRule> rules2 = _wrongdeepMapRuleSameDestination2;

            //Act
            var resultDict1 = JsonMapper.MapToDictionary(jsonString, rules1);
            var resultDict2 = JsonMapper.MapToDictionary(jsonString, rules2);

            //Assert
            Assert.NotNull(resultDict1["Product"]);
            Assert.Equal(_productName, resultDict1["Product"]["Name"]);
            Assert.Equal(_releaseDateStr, resultDict1["Product"]["ReleaseDate"]);
            Assert.Null(resultDict1["Product"]["Model"].ToObject<JValue>().Value);
            Assert.Null(resultDict1["Product"]["Price"].ToObject<JValue>().Value);

            Assert.NotNull(resultDict2["Product"]);
            Assert.Null(resultDict2["Product"]["Name"].ToObject<JValue>().Value);
            Assert.Null(resultDict2["Product"]["ReleaseDate"].ToObject<JValue>().Value);
            Assert.Equal(_modelName, resultDict2["Product"]["Model"]);
            Assert.Equal(_price, resultDict2["Product"]["Price"]);
        }

        [Fact]
        public void MapToDictionary_ValidMappingSimpleProperty_ReturnsSinglePropertyMappedDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _singleMapRule;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, rules);

            //Assert
            Assert.NotNull(resultDict["ProductName"]);
            Assert.NotNull(resultDict["ProductPrice"]);
        }

        [Fact]
        public void MapToDictionary_InvalidMappingSimpleProperty_ReturnsNullSinglePropertyMappedDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _wrongSingleMapRule;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, rules);

            //Assert
            Assert.Null(resultDict["ProductName"]);
            Assert.Null(resultDict["ProductPrice"]);
        }

        [Fact]
        public void MapToDictionary_ValidComplexMappingSameDestinationObject_ReturnsDeepPropertyMappedObjectDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _complexMapRuleSameDestination;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, rules);

            //Assert
            Assert.NotNull(resultDict["Product"]);
            Assert.NotNull(resultDict["Product"]["name"]);
            Assert.NotNull(resultDict["Product"]["price"]);
        }

        [Fact]
        public void MapToDictionary_SomeInvalidComplexMappingSameDestinationObject_ReturnsNullDeepPropertyMappedObjectDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules1 = _wrongComplexMapRuleSameDestination1;
            List<MappingRule> rules2 = _wrongComplexMapRuleSameDestination2;

            //Act
            var resultDict1 = JsonMapper.MapToDictionary(jsonString, rules1);
            var resultDict2 = JsonMapper.MapToDictionary(jsonString, rules2);

            //Assert
            Assert.NotNull(resultDict1["Product"]);
            Assert.NotNull(resultDict1["Product"]["name"]);
            Assert.Null(resultDict1["Product"]["price"]);

            Assert.NotNull(resultDict2["Product"]);
            Assert.Null(resultDict2["Product"]["name"]);
            Assert.NotNull(resultDict2["Product"]["price"]);
        }

        [Fact]
        public void MapToDictionary_ValidComplexMappingSameDestinationObjectWithMappingProperties_ReturnsDeepPropertyMappedObjectDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules = _complexDeepMapRuleSameDestination;

            //Act
            var resultDict = JsonMapper.MapToDictionary(jsonString, rules);

            //Assert
            Assert.NotNull(resultDict["Product"]);
            Assert.NotNull(resultDict["Product"]["Name"]);
            Assert.NotNull(resultDict["Product"]["Price"]);
        }

        [Fact]
        public void MapToDictionary_InvalidComplexMappingSameDestinationObjectWithMappingProperties_ReturnsSomeNullDeepPropertyMappedObjectDictionary()
        {
            //Arrange
            string jsonString = _getDummyJsonString;
            List<MappingRule> rules1 = _wrongComplexDeepMapRuleSameDestination1;
            List<MappingRule> rules2 = _wrongComplexDeepMapRuleSameDestination2;
            List<MappingRule> rules3 = _wrongComplexDeepMapRuleSameDestination3;
            List<MappingRule> rules4 = _wrongComplexDeepMapRuleSameDestination4;

            //Act
            var resultDict1 = JsonMapper.MapToDictionary(jsonString, rules1);
            var resultDict2 = JsonMapper.MapToDictionary(jsonString, rules2);
            var resultDict3 = JsonMapper.MapToDictionary(jsonString, rules3);
            var resultDict4 = JsonMapper.MapToDictionary(jsonString, rules4);

            //Assert
            Assert.NotNull(resultDict1["Product"]);
            Assert.NotNull(resultDict1["Product"]["Name"]);
            Assert.Null(resultDict1["Product"]["Price"]);

            Assert.NotNull(resultDict2["Product"]);
            Assert.NotNull(resultDict2["Product"]["Name"]);
            Assert.Null(resultDict2["Product"]["Price"].ToObject<JValue>().Value);

            Assert.NotNull(resultDict3["Product"]);
            Assert.Null(resultDict3["Product"]["Name"]);
            Assert.NotNull(resultDict3["Product"]["Price"]);

            Assert.NotNull(resultDict4["Product"]);
            Assert.Null(resultDict4["Product"]["Name"].ToObject<JValue>().Value);
            Assert.NotNull(resultDict4["Product"]["Price"]);
        }
    }
}
