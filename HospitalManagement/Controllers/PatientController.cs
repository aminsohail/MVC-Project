using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using HospitalManagement.DAL;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Controllers
{
     [EnableCors("MyAllowSpecificOrigins")]
    public class PatientController : Controller
    {
        // static List<PatientModel> patients = new List<PatientModel>();


        //  public IActionResult Add()
        // {
        //   return View("PatientAdd", patients); 
        // }

        public IActionResult Submit([FromBody] PatientModel obj)
        {
            // string name = Request.Form["PatientName"].ToString();
            //string problem = Request.Form["PatientProblem"].ToString();
            //return Content("Patient Name is "+name);
            // return Content("You Had Submitted " + name + " he has Problem " + problem);
            //return Content("You Had Submitted " + obj.name + " he has Problem " + obj.problemDescription);

            //    patients.Add(obj); //in c# Add is used insted of push like in JS
            // return View("PatientAdd", patients);

            //  return Json(patients);



            // create the object of context

            var context = new ValidationContext(obj, null, null);

            //if there are errors then it will fill in ValidationResult collection

            var result = new List<ValidationResult>();

            //class says that validate the obj and if there is error then fill in result

            var isValid = Validator.TryValidateObject(obj, context, result, true);

            if (result.Count == 0)
            {
                PatientDAL dal = new PatientDAL();
                dal.Database.EnsureCreated(); // ensure table is created or not
                dal.Add(obj); // here obj is UI comming object //it adds in memory not in database
                dal.SaveChanges();// pysical commit save to database

                // after saving we have to display also for that
                //create a list of model and fetch records 
                // query the dal
                //All records ARE FETCH
                // and just return the records to angular

                List<PatientModel> recs = dal.PatientModels.ToList<PatientModel>();
                // return Json(recs);

                return StatusCode(200, recs); // 200 for success 
            }
            else {
                return StatusCode(500, result); // 500 for internal server error
            }
        }

        //public IActionResult ViewPatients()
        //{
          //  return View("DisplayPatients", patients);
       // }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }


        public IActionResult Search(string patientName)
        {
            PatientDAL dal = new PatientDAL();
            List<PatientModel> search = ( from temp in dal.PatientModels
                                          where temp.name == patientName
                                          select temp )
                                          .ToList<PatientModel>();

            return Ok(search);
        }
    }
}