using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.Mapper.Tests.Utils
{
    public class DummyObjectWithAttributes
    {
        public DummyObjectWithAttributes()
        {
            Products = new List<DummyProductWithAttributes>();
        }

        public List<DummyProductWithAttributes> Products { get; set; }
    }
}
