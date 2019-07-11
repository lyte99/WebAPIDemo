using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiClassV2.Models
{
    public class AFElementSearchResults
    {
        public class Links
        {
            public string First { get; set; }
            public string Last { get; set; }
        }

        public class ExtendedProperties
        {
        }

        public class Links2
        {
            public string Self { get; set; }
            public string Analyses { get; set; }
            public string Attributes { get; set; }
            public string Elements { get; set; }
            public string Database { get; set; }
            public string Parent { get; set; }
            public string Template { get; set; }
            public string Categories { get; set; }
            public string EventFrames { get; set; }
            public string InterpolatedData { get; set; }
            public string RecordedData { get; set; }
            public string PlotData { get; set; }
            public string SummaryData { get; set; }
            public string Value { get; set; }
            public string EndValue { get; set; }
            public string Security { get; set; }
            public string SecurityEntries { get; set; }
            public string NotificationRules { get; set; }
        }

        public class Item
        {
            public string WebId { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Path { get; set; }
            public string TemplateName { get; set; }
            public bool HasChildren { get; set; }
            public List<object> CategoryNames { get; set; }
            public ExtendedProperties ExtendedProperties { get; set; }
            public Links2 Links { get; set; }
        }

        public class RootObject
        {
            public Links Links { get; set; }
            public List<Item> Items { get; set; }
        }
    }
}
