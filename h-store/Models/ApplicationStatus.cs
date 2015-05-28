using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h_store.Models
{

    public class UserSubsciptions
    {
        public bool active { get; set; }
        public string type { get; set; }
        public int id { get; set; }
        public string uri { get; set; }
        public string hashKey { get; set; }
    }
    public class FlashData
    {
        public string[] success { get; set; }
    }
    public class UserApplicationData
    {
        public string userid { get; set; }
        public string csrf { get; set; }

        public UserSubsciptions[] subscriptions { get; set; }
    }

    public class ApplicationErrors
    {
        public string password { get; set; }
        public string username { get; set; }
    }
    public class ApplicationStatus
    {
        public string status { get; set; }
        public string reason { get; set; }
        public UserApplicationData model { get; set; }
        public FlashData flash { get; set; }
        public UserSubsciptions[] subscriptions { get; set; }
        public ApplicationErrors errors { get; set; }


        
    }

}