using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cTaxi2.ViewModel
{
    public class DriverViewModel
    {
        [Display(Name = "Driver id")]
        public int LicenceID { get; set; }
        [Required]
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Begin Job")]
        public double BeginJob { get; set; }

        [Display(Name = "Last Eye Check")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastEyeCheck { get; set; }

        public string Adress { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}