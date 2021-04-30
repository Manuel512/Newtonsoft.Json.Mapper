using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.Mapper
{
    public class MappingRule : BaseMappingRule
    {
        public MappingRule(string from, string to, string mappingType) : base(from, to)
        {
            MappingType = mappingType ?? throw new ArgumentNullException(nameof(mappingType));
            MappingProperties = new List<BaseMappingRule>();
        }

        public MappingRule()
        {
            MappingProperties = new List<BaseMappingRule>();
        }

        public List<BaseMappingRule> MappingProperties { get; set; }
        public string MappingType { get; set; }

        public MappingRule AddMapProperty(string from, string to)
        {
            MappingProperties.Add(new BaseMappingRule(from, to));
            return this;
        }
    }
}
