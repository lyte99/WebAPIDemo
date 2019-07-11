using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiClassV2.Models
{
    public class AFAttributeRecordedValues
    {

        public class Links
        {
        }

        public class Item
        {
            public DateTime Timestamp { get; set; }
            public object Value { get; set; }
            public string UnitsAbbreviation { get; set; }
            public bool Good { get; set; }
            public bool Questionable { get; set; }
            public bool Substituted { get; set; }
            public bool Annotated { get; set; }
        }

        public class RootObject
        {
            public Links Links { get; set; }
            public List<Item> Items { get; set; }
            public string UnitsAbbreviation { get; set; }
        }
    }
}
