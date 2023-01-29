using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical_project_
{
    public class PatientInfo
    {
        [Required(ErrorMessage ="Name is required")]
        //[Range(1, 100)]

        public string Patient_Name { get; set; }
        [Required(ErrorMessage = "ID is required")]
        public string Patient_ID { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Patient_Address { get; set; }
        [Required(ErrorMessage = "Phone_number is required")]
        public string Phone_number { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }





    }
}
