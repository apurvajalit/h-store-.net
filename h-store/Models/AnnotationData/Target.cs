using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h_store.Models.AnnotationData
{
    public class Target
    {
        public string source { get; set; }
        public Position pos { get; set; }
        public Selector[] selector { get; set; }
    }
}