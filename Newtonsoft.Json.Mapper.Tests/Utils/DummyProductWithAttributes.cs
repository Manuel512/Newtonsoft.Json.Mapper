using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.Mapper.Tests.Utils
{
    public class DummyProductWithAttributes
    {
        public string Name { get; set; }

        [JsonProperty("release_date")]
        public DateTime? ReleaseDate { get; set; }
    }
}
