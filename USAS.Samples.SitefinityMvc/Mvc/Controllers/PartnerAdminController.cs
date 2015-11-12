using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Telerik.Sitefinity.Mvc;
using USAS.Samples.Core.ExceptionHandling;
using USAS.Samples.SitefinityMvc.Mvc.Interfaces;
using USAS.Samples.SitefinityMvc.Mvc.Models;

namespace USAS.Samples.SitefinityMvc.Mvc.Controllers
{
    [CustomHandleError]   
    [ControllerToolboxItem(Name = "Partner_Admin", Title = "Partner Admin", SectionName = "USAS" )]
    public class PartnerAdminController : Controller
    {
        private readonly IGreekPartnerRepository _greekPartnerRepository;

        public PartnerAdminController(IGreekPartnerRepository greekPartnerRepository)
        {
            _greekPartnerRepository = greekPartnerRepository;
        }

        // GET: /GreekPartner/PartnerAdmin/
        public ActionResult Index()
        {
            return View("GreekPartnerList");
        }

 
        public ActionResult ReadPartners([DataSourceRequest] DataSourceRequest request)
        {
            List<GreekPartnerModel> partners = _greekPartnerRepository.GetAllGreekPartners();
            return Json(partners.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdatePartner([DataSourceRequest] DataSourceRequest request, GreekPartnerModel partner)
        {
            if (partner != null && ModelState.IsValid)
            {
                _greekPartnerRepository.UpdatePartner(partner);
            }

            return Json(new[] { partner }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult CreatePartner([DataSourceRequest] DataSourceRequest request, GreekPartnerModel partner)
        {
            if (partner != null && ModelState.IsValid)
            {
                _greekPartnerRepository.CreatePartner(partner);
            }

            return Json(new[] { partner }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeletePartner([DataSourceRequest] DataSourceRequest request, GreekPartnerModel partner)
        {
            if (partner != null)
            {
                _greekPartnerRepository.DeletePartner(partner);
            }

            return Json(new[] { partner }.ToDataSourceResult(request, ModelState));
        }

        [Route("ajax/partner-detail/helpdetails")]
        public JsonResult HelpDetails()
        {
            return  Json("The User Signup Pledge is an contract that every partner member must agree to prior to joining the partner", JsonRequestBehavior.AllowGet);
        }

    }
}
