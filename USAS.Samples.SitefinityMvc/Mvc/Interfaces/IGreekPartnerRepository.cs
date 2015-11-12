using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USAS.Samples.SitefinityMvc.Mvc.Models;

namespace USAS.Samples.SitefinityMvc.Mvc.Interfaces
{
    public interface IGreekPartnerRepository
    {
        GreekPartnerModel GetGreekPartnerByID(int partnerID);
        List<GreekPartnerModel> GetAllGreekPartners();
        GreekPartnerModel UpdatePartner(GreekPartnerModel partner);
        GreekPartnerModel CreatePartner(GreekPartnerModel partner);
        void DeletePartner(GreekPartnerModel partner);
    }
}