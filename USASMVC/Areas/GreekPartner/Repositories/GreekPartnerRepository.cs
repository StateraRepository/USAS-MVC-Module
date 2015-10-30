using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using USASMVC.Areas.GreekPartner.Models;
using USASMVC.Areas.GreekPartner.Interfaces;
using USASMVC.Raven;
using Raven.Client;
using Newtonsoft.Json;

namespace USASMVC.Areas.GreekPartner.Repositories
{
    public class GreekPartnerRepository : IGreekPartnerRepository
    {
        
        public GreekPartnerModel GetGreekPartnerByID(int partnerID)
        {
            using (IDocumentSession session = DataDocumentStore.Store.OpenSession())
            {
                var results = from p in session.Query<GreekPartnerModel>()
                              where p.Id == partnerID.ToString()
                              select p;
                return results.First();
            }
            
        }

        public List<GreekPartnerModel> GetAllGreekPartners()
        {
            List<GreekPartnerModel> partners = new List<GreekPartnerModel>();
            using (IDocumentSession session = DataDocumentStore.Store.OpenSession())
            {
                var results = from p in session.Query<GreekPartnerModel>()
                              select p;
                if (results.Count() > 0 )
                {
                    partners = results.ToList<GreekPartnerModel>();
                }
            }


            return partners;

        }

        public GreekPartnerModel UpdatePartner(GreekPartnerModel partner)
        {
            //var modelData = JsonConvert.SerializeObject(partner);

            using (IDocumentSession session = DataDocumentStore.Store.OpenSession())
            {
                session.Store(partner);
                session.SaveChanges();
            }

            return partner;

        }

        public GreekPartnerModel CreatePartner(GreekPartnerModel partner)
        {
            
            using (IDocumentSession session = DataDocumentStore.Store.OpenSession())
            {
                session.Store(partner);
                session.SaveChanges();
            }

            return partner;            
        }

        public void DeletePartner(GreekPartnerModel partner)
        {
            using (IDocumentSession session = DataDocumentStore.Store.OpenSession())
            {
                var delPartner = session.Load<GreekPartnerModel>(partner.Id);
                session.Delete(delPartner);
                session.SaveChanges();
            }


        }



    }
}