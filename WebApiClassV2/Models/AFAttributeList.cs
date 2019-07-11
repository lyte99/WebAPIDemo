using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiClassV2.Models
{
    public class AFAttributeList
    {
        public class Links
        {
            public string First { get; set; }
            public string Last { get; set; }
        }

        public class Links2
        {
            public string Self { get; set; }
            public string Attributes { get; set; }
            public string Element { get; set; }
            public string InterpolatedData { get; set; }
            public string RecordedData { get; set; }
            public string PlotData { get; set; }
            public string SummaryData { get; set; }
            public string Value { get; set; }
            public string EndValue { get; set; }
            public string Categories { get; set; }
            public string Point { get; set; }
        }

        public class Item
        {
            public string WebId { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Path { get; set; }
            public string Type { get; set; }
            public string TypeQualifier { get; set; }
            public string DefaultUnitsName { get; set; }
            public string DefaultUnitsNameAbbreviation { get; set; }
            public int DisplayDigits { get; set; }
            public string DataReferencePlugIn { get; set; }
            public string ConfigString { get; set; }
            public bool IsConfigurationItem { get; set; }
            public bool IsExcluded { get; set; }
            public bool IsHidden { get; set; }
            public bool IsManualDataEntry { get; set; }
            public bool HasChildren { get; set; }
            public List<object> CategoryNames { get; set; }
            public bool Step { get; set; }
            public string TraitName { get; set; }
            public double? Span { get; set; }
            public double? Zero { get; set; }
            public Links2 Links { get; set; }
        }

        public class RootObject
        {
            public Links Links { get; set; }
            public List<Item> Items { get; set; }
        }
    }
}
