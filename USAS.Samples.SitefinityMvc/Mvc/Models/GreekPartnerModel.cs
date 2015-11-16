using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace USAS.Samples.SitefinityMvc.Mvc.Models
{
    public class GreekPartnerModel
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Required(ErrorMessage="Partner Name is required")]
        [Display(Name="Partner Name")]
        [StringLength(80, MinimumLength=3, ErrorMessage="Name cannot exceed 80 characters")]
        public string PartnerName { get; set; }

        [Required(ErrorMessage = "User Signup Pledge is required")]
        [Display(Name = "User Signup Pledge")]
        [UIHint("RichText")]
        public string UserSignupPledge { get; set; }

    }
}