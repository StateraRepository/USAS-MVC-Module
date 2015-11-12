using System.Web.Mvc;

namespace USASMVC.Areas.GreekPartner
{
    public class GreekPartnerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GreekPartner";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GreekPartner_default",
                "GreekPartner/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
