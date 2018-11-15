using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appalachian_Trail_3._0.Models
{
    public class UserInformation
    {
        [Key]
        public int UserID { get; set; }

    
        [Required(ErrorMessage = "Please provide your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide your username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please provide your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please provide your Birthdate")]
        public DateTime? BirthDate { get; internal set; }

        [Required(ErrorMessage = "Please provide your email")]
        public string Email { get; set; }

        public string Gender { get; set; }

        public DateTime CreateDate { get; internal set; }

        //public IEnumerable<ShelterInformation> ShelterInformation { get; set; }

        public IEnumerable<Distance> Distance { get; set; }
    }
}