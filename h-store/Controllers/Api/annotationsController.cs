using AttributeRouting.Web.Mvc;
using h_store.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using h_store.Models.AnnotationData;
using Newtonsoft.Json;
using System.Data.Entity;

namespace h_store.Controllers
{

    public class annotationsController : ApiController
    {

        //static IList<ClientAnnotationData> annotationsList = new List<ClientAnnotationData>();
        [HttpGet]
        public JObject storeInfo()
        {

            JObject json = JObject.Parse(new StoreApiInfo().info);
            return json;
        }

        [HttpGet]
        public SearchResponse Search(int limit, int offset, string order, string sort, string uri)
        {
            SearchResponse res = new SearchResponse();
            List<Annotation> annotationList = null;
            DBContextHandler dbContextHandler = new DBContextHandler();
            dbContextHandler.CreateDataContext();
            try
            {

                using (dbContextHandler.GetDataContext())
                {
                    annotationList = (from annotations in dbContextHandler.context.Annotations
                                  where annotations.uri == uri
                                  select annotations).ToList();

                }
            }
            catch
            {
                throw;
            }
            finally
            {
                dbContextHandler.DisposeContext();
            }

            res.total = annotationList.Count;
            res.rows = new List<ClientAnnotationData>();

            foreach (Annotation annotationEntry in annotationList)
                res.rows.Add(new ClientAnnotationData(annotationEntry));
    
            return res;
        }

        [HttpPost]
        public ClientAnnotationData annotations([FromBody]ClientAnnotationData annotation)
        {
            DBContextHandler dbContextHandler = new DBContextHandler();

            annotation.updated = "2015-03-31T09:49:11.401667+00:00";

            annotation.created = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            annotation.consumer = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            
            //annotationsList.Add(annotation);
            Annotation annotaionForDB = annotation.ToAnnotation();
            annotaionForDB.User = (User)(System.Web.HttpContext.Current.Session["user"]);
            annotaionForDB.UserId = annotaionForDB.User.Id;
            dbContextHandler.CreateDataContext();
            try
            {

                using (dbContextHandler.GetDataContext())
                {
                    dbContextHandler.context.Entry(annotaionForDB).State = EntityState.Added;
                    dbContextHandler.context.SaveChanges();

                }
            }
            catch
            {
                throw;
            }
            finally
            {
                dbContextHandler.DisposeContext();
            }
 
            return annotation;

        }


        [HttpGet]
        public ClientAnnotationData annotations(long id)
        {
            Annotation annotation = null;
            DBContextHandler dbContextHandler = new DBContextHandler();
            dbContextHandler.CreateDataContext();
            try
            {

                using (dbContextHandler.GetDataContext())
                {
                    annotation = (from annotations in dbContextHandler.context.Annotations
                                  where annotations.Id == id
                                  select annotations).ToList().FirstOrDefault<Annotation>();

                }
            }
            catch
            {
                throw;
            }
            finally
            {
                dbContextHandler.DisposeContext();
            }

            return new ClientAnnotationData(annotation);
           
        }


        [System.Web.Http.HttpPut]
        //[Route("api/Annotation/annotations/{id}")]
        public ClientAnnotationData annotations(long id, [FromBody] ClientAnnotationData annotation)
        {
            DBContextHandler dbContextHandler = new DBContextHandler();
           // annotation.User = (User)(System.Web.HttpContext.Current.Session["user"]);
           // annotation.UserId = annotation.User.Id;
            dbContextHandler.CreateDataContext();
            try
            {

                using (dbContextHandler.GetDataContext())
                {
                    dbContextHandler.context.Entry(annotation).State = EntityState.Modified;
                    dbContextHandler.context.SaveChanges();

                }
            }
            catch
            {
                throw;
            }
            finally
            {
                dbContextHandler.DisposeContext();
            }

            return annotation;
        }


        //[System.Web.Http.HttpDelete]
        ////[Route("api/Annotation/annotations/{id}")]
        //public System.Web.Mvc.ActionResult annotationsDelete(long id, [FromBody] Annotation req)
        //{
        //    return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.NoContent);
        //}

      }
}
