using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Document;

namespace USAS.Samples.SitefinityMvc.Raven
{
    public class DataDocumentStore
    {
        private static IDocumentStore store;

        public static IDocumentStore Store
        {
            get
            {
                if (store == null)
                    throw new InvalidOperationException(
                      "IDocumentStore has not been initialized.");
                return store;
            }
        }

        public static IDocumentStore Initialize()
        {
            store = new DocumentStore { ConnectionStringName = "Server" };            
            store.Initialize();
            return store;
        }
    }
}