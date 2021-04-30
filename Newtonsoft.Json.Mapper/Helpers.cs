using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newtonsoft.Json.Mapper
{
    internal static class Helpers
    {
        private static List<string> _validMappingTypes = new List<string>
        {
            "Array",
            "Object",
            "Property",
            "Value"
        };

        private static bool IsValidType(string type) => _validMappingTypes.Contains(type);

        public static JToken MapPropertyValue(JObject source, MappingRule rule)
        {
            if (rule == null)
                throw new ArgumentNullException($"[{nameof(rule.From)}] is not defined.", nameof(rule.From));

            if (string.IsNullOrWhiteSpace(rule.From))
                throw new ArgumentException($"Invalid [{nameof(rule.From)}] property or is not defined.", nameof(rule.From));

            if (string.IsNullOrWhiteSpace(rule.To))
                throw new ArgumentException($"Invalid [{nameof(rule.To)}] property or is not defined.", nameof(rule.To));

            if (!IsValidType(rule.MappingType))
                throw new ArgumentException($"Invalid [{nameof(rule.MappingType)}] property or is not defined.", nameof(rule.MappingType));

            try
            {
                if (rule.MappingType == "Array")
                {
                    var tokens = source.SelectTokens(rule.From).ToList();
                    if (rule.MappingProperties.Count > 0)
                        return MapProperties(tokens, rule.MappingProperties);

                    var array = new JArray(tokens);

                    return array;
                }

                var token = source.SelectToken(rule.From);

                if (rule.MappingType == "Object")
                {
                    if (rule.MappingProperties.Count > 0)
                        return MapProperties(token, rule.MappingProperties);

                    return token?.ToObject<JObject>();
                }

                if (rule.MappingType == "Property")
                {
                    var jObj = new JObject(token?.Parent);
                    if (rule.MappingProperties.Count > 0)
                    {
                        var mappedObj = MapProperties(jObj, rule.MappingProperties);
                        return mappedObj;
                    }

                    return jObj;
                }

                return token;

            }
            catch (Exception ex)
            {
            }

            return null;
        }

        private static JArray MapProperties(IEnumerable<JToken> tokens, List<BaseMappingRule> rules)
        {
            return new JArray(tokens.Select(x =>
            {
                return MapProperties(x, rules);
            }));
        }

        private static JObject MapProperties(JToken token, List<BaseMappingRule> rules)
        {
            var obj = new JObject();

            rules.ForEach(p => {
                obj.Add(new JProperty(p.To, token[p.From]));
            });

            return obj;
        }
    }
}
