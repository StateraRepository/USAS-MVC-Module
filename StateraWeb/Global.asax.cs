using SitefinityWebApp.Core;
using System;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Mvc;
using USAS.Samples.SitefinityMvc.Raven;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            DataDocumentStore.Initialize();
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
            BundleTable.VirtualPathProvider = HostingEnvironment.VirtualPathProvider﻿;
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        // Sitefinity Bootstraper Bootstrapped event
        void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        { 
            ObjectFactory.Container.RegisterType<ISitefinityControllerFactory, NinjectControllerFactory>(new ContainerControlledLifetimeManager());

            var factory = ObjectFactory.Resolve<ISitefinityControllerFactory>();
            ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}