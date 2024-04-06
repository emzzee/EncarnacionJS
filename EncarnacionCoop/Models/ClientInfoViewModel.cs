using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EncarnacionCoop.Models
{
    public class ClientInfoViewModel
    {

        public int Id { get; set; }

        [DisplayName("Enter Usertype")]
        [Required]
        public string? UserType { get; set; }


        [DisplayName("Enter First Name")]
        [Required]
        public string? FirstName { get; set; }

        [DisplayName("Enter Middle Name")]
        [Required]
        public string? MiddleName { get; set; }

        [DisplayName("Enter Last Name")]
        [Required]
        public string? LastName { get; set; }

        [DisplayName("Enter Address")]
        [Required]
        public string? Address { get; set; }

        [DisplayName("ZipCode")]
        [Required]
        public int? ZipCode { get; set; }

        [Required]
        public DateTime? Birthday { get; set; }

        [DisplayName("Enter Age")]
        [Required]
        public int? Age { get; set; }

        [DisplayName("Name of Father")]
        [Required]
        public string? NameOfFather { get; set; }

        [DisplayName("Name of Mother")]
        [Required]
        public string? NameOfMother { get; set; }

        [DisplayName("Enter Status")]
        [Required]
        public string? CivilStatus { get; set; }

        [DisplayName("Religion")]
        [Required]
        public string? Religion { get; set; }

        [DisplayName("Occupation")]
        [Required]
        public string? Occupatioin { get; set; }
    }
}