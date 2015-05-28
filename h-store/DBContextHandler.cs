using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace h_store
{
    public class DBContextHandler
    {
        public ADOModelContainer context;
        public string connectionString;

        public void CreateDataContext(bool createContext = true)
        {
            if (createContext)
            {

            }
            //this.connectionString = ConfigurationManager.ConnectionStrings["ADOModel"].ToString();
        }

        public void SetDataContext(ADOModelContainer localContext)
        {
            this.context = localContext;
        }

        public ADOModelContainer GetDataContext()
        {
            this.context = new ADOModelContainer();
            this.context.Configuration.LazyLoadingEnabled = false;
            this.context.Configuration.ProxyCreationEnabled = false;

            return this.context;

        }

        public void DisposeContext()
        {
            if (this.context != null)
            {

                this.context.Dispose();
                this.context = null;
            }
        }
    }
}