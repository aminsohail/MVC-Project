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
        [Key]
        public int id{ get; set; }

        [Required]
         [RegularExpression("^[a-z]{1,10}$")]
        public string name { get; set; }

       // public string problemDescription { get; set; }

         public List<Problem> problems { get; set; }

    }

      public class Problem
       {

          public int id { get; set; }
          public string problemDescription { get; set; }
           public PatientModel patient { get; set; }   //Inverse Navigation Property
      }
}
