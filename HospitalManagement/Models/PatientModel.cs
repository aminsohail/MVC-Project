using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HospitalManagement.Models
{
    public class PatientModel
    {

         [Required]
         [RegularExpression("^[a-z]{1,10}$")]
        public string name { get; set; }

        [Required]
        public string problemDescription { get; set; }
    }
}
