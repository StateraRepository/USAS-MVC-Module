using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USASMVC.Areas.GreekPartner.Models;

namespace USASMVC.Areas.GreekPartner.Interfaces
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