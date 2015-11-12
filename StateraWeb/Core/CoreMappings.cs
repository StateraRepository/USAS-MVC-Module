using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.Models.LanguageSelector;
using Telerik.Sitefinity.Localization.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization.UrlLocalizationStrategies;
using Telerik.Sitefinity.Abstractions;
using USAS.Samples.SitefinityMvc.Mvc.Interfaces;
using USAS.Samples.SitefinityMvc.Mvc.Repositories;

namespace SitefinityWebApp.Core
{
    public class CoreMappings : NinjectModule
    {
        public override void Load()
        {

            Bind<IGreekPartnerRepository>().To<GreekPartnerRepository>();
        }
    }
}