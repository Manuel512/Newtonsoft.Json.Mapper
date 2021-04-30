using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Newtonsoft.Json.Mapper
{
    /// <summary>
    /// An static class that holds mapping schema functionality
    /// </summary>
    /// <remarks>
    /// This class can Map to a <see cref="IDictionary{String, JToken}"/>, json <see cref="String"/> or a type of T.
    /// </remarks>
    public static class JsonMapper
    {
        /// <summary>
        /// Map a json string to a Dictionary with new schema
        /// </summary>
        /// <param name="sourceJson">Source json string to map from</param>
        /// <param name="mappingRules">List of rules that applies the mapping for the new schema</param>
        /// <returns><see cref="IDictionary{String, JToken}"/> with the new mapping schema</returns>
        public static IDictionary<string, JToken> MapToDictionary(string sourceJson, List<MappingRule> mappingRules)
        {
            var source = JObject.Parse(sourceJson);
            IDictionary<string, JToken> dest = new Dictionary<string, JToken>();

            foreach (var rule in mappingRules)
            {
                var mappedProperty = Helpers.MapPropertyValue(source, rule);
                if (dest.ContainsKey(rule.To))
                {
                    var token = dest[rule.To];
                    if (token != null)
                    {
                        if (mappedProperty != null)
                            foreach (var prop in mappedProperty.Children<JProperty>())
                                token.Last.AddAfterSelf(prop);
                        
                        dest[rule.To] = token;
                        continue;
                    }
                }
                
                dest[rule.To] = mappedProperty;
            }

            return dest;
        }

        /// <summary>
        /// Map a json string to a new json string schema
        /// </summary>
        /// <param name="sourceJson">Source json string to map from</param>
        /// <param name="mappingRules">List of rules that applies the mapping for the new schema</param>
        /// <returns>json string with the new mapping schema</returns>
        public static string MapToJsonString(string sourceJson, List<MappingRule> mappingRules)
        {
            var dict = MapToDictionary(sourceJson, mappingRules);
            return JsonConvert.SerializeObject(dict);
        }

        /// <summary>
        /// Map a json string to a type schema
        /// </summary>
        /// <param name="sourceJson">Source json string to map from</param>
        /// <param name="mappingRules">List of rules that applies to mapping for the new schema</param>
        /// <typeparam name="T">A type that will map the new schema to.</typeparam>
        /// <returns>string a type the new mapping schema</returns>
        public static T MapTo<T>(string sourceJson, List<MappingRule> mappingRules)
        {
            var dict = MapToDictionary(sourceJson, mappingRules);
            var obj = JObject.FromObject(dict);
            return obj.ToObject<T>();
        }
    }
}
