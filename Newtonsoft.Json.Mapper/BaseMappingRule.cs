using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.Mapper
{
    public class BaseMappingRule
    {
        public BaseMappingRule()
        {

        }

        public BaseMappingRule(string from, string to)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
        }

        public string From { get; set; }
        public string To { get; set; }
    }
}
