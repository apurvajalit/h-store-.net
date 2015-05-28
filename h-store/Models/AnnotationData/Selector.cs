using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h_store.Models.AnnotationData
{
    public class Selector
    {
        public string type { get; set; }
        public string startContainer { get; set; }
        public string endContainer { get; set; }
        public int startOffset { get; set; }
        public string endOffset { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public string prefix { get; set; }
        public string exact { get; set; }
        public string suffix { get; set; }
        public string value { get; set; }
    }
}