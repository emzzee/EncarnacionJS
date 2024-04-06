using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EncarnacionCoop.Models
{
    public class UserTypeViewModel
    {

        public int Id { get; set; }

        [DisplayName("Enter Usertype")]
        public string? Name { get; set; }
    }
}