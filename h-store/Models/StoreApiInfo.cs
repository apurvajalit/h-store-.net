using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h_store.Models
{

    public class StoreApiInfo
    {
        public string info = "{\"message\": \"Annotator Store API\",\"links\": {\"search\": {\"url\": \"http://localhost:29142/api/annotations/search\", \"method\": \"GET\", \"desc\": \"Basic search API\"}, \"annotation\": {\"read\": {\"url\": \"http://localhost:29142/api/annotations/:id\", \"method\": \"GET\", \"desc\": \"Get an existing annotation\"}, \"create\": {\"url\": \"http://localhost:29142/api/annotations\", \"method\": \"POST\", \"desc\": \"Create a new annotation\"}, \"update\": {\"url\": \"http://localhost:29142/api/annotations/:id\", \"method\": \"PUT\", \"desc\": \"Update an existing annotation\"}, \"delete\": {\"url\": \"http://localhost:29142/api/annotations/:id\", \"method\": \"DELETE\", \"desc\": \"Delete an annotation\"}}}}";
        public string status = "{\"status\": \"okay\", \"model\": {\"userid\": \"acct:apurvajalit@hypothes.is\", \"csrf\": \"87891198d09e654f71dd5443513baa194e95b437\"}, \"flash\": {}}";
    }
}