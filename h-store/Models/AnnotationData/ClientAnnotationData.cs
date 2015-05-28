using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using h_store;
using Newtonsoft.Json;

namespace h_store.Models.AnnotationData
{
    public class ClientAnnotationData
    {
        public string updated { get; set; }
        public Target[] target { get; set; }
        public string created { get; set; }
        public string text { get; set; }
        public string[] tags { get; set; }
        public string uri { get; set; }
        public string user { get; set; }
        public Document document { get; set; }
        public string consumer { get; set; }
        public int id { get; set; }
        public Object permissions { get; set; }


        public ClientAnnotationData(Annotation annotation)
        {
           
            updated = annotation.updated;
            target = JsonConvert.DeserializeObject<Target[]>(annotation.target);
            created = annotation.created;
            text = annotation.text;
            tags = JsonConvert.DeserializeObject<string[]>(annotation.tags);
            uri = annotation.uri;
            //user = annotation.User.username;
            document = JsonConvert.DeserializeObject<Document>(annotation.document);
            consumer = annotation.consumer;
            id = annotation.Id;
            permissions = JsonConvert.DeserializeObject(annotation.permissions);
        }

        public ClientAnnotationData()
        {



        }
        public Annotation ToAnnotation()
        {
            Annotation annotation = new Annotation();
            annotation.updated = this.updated;
            annotation.target = JsonConvert.SerializeObject(this.target);
            annotation.created = this.updated;
            annotation.text = this.text;
            annotation.uri = this.uri;
            annotation.tags = JsonConvert.SerializeObject(this.tags);
            annotation.document = JsonConvert.SerializeObject(this.document);
            annotation.consumer = this.consumer;
            annotation.Id = this.id;
            annotation.permissions = JsonConvert.SerializeObject(this.permissions);

            return annotation;
        }
    }

   

}