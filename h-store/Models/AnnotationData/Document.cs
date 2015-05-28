using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h_store.Models.AnnotationData
{
    public class Document
    {
        public Eprints eprints { get; set; }
        public string title { get; set; }

        public Object twitter { get; set; }
        public Object dc { get; set; }
        public Object prism { get; set; }
        public Object highwire { get; set; }
        public Object facebook { get; set; }
        public Object link { get; set; }

    }
}