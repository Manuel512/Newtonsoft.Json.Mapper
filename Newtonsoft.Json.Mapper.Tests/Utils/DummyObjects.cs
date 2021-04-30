using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.Json.Mapper.Tests.Utils
{
    public class DummyObjects
    {
        public DummyObjects()
        {
            Products = new List<DummyProduct>();
        }

        public List<DummyProduct> Products { get; set; }
    }
}
