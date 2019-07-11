using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiClassV2.Models
{
    public class SingleTagResponse
    {
        public DateTime Timestamp { get; set; }
        public int Value { get; set; }
        public string UnitsAbbreviation { get; set; }
        public bool Good { get; set; }
        public bool Questionable { get; set; }
        public bool Substituted { get; set; }
        public bool Annotated { get; set; }
    }
}
