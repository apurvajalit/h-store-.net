using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h_store.Models.AnnotationData
{
    public class SearchResponse
    {
        public int total = 0;
        public IList<ClientAnnotationData> rows = new List<ClientAnnotationData>();
        
    }
}