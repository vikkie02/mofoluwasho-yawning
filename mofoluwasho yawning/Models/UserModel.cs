using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mofoluwasho_yawning.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [DisplayName("Alternative Number")]
        [DataType(DataType.PhoneNumber)]
        public string AlternativeNumber { get; set; }
        [DisplayName("NIN")]
        public string NIN { get; set; }
        [DisplayName("BVN")]
        public string BVN { get; set; }
        [DisplayName("My Address")]
        public string MyAddress { get; set; }

        [DisplayName("EmergencyContactName")]
        public string EmergencyContactName { get; set; }
        [DisplayName("EmergencyContactNumber")]
        [DataType(DataType.PhoneNumber)]
        public string EmergencyContactNumber { get; set; }
















    }
}
