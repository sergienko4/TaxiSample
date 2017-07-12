using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cTaxi2.Models
{
    public class DriverModel
    {

        [Display(Name = "Driver id")]
        public int LicenceID { get; set; }
        [Required]

        [Display(Name = "Full name")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Begin Job")]
        public DateTime BeginJob { get; set; }
        [Display(Name = "Last Eye Check")]
        public DateTime LastEyeCheck { get; set; }

        public string Adress { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}