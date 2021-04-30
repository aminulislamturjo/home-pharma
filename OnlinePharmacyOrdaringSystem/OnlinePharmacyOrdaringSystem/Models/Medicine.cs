using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlinePharmacyOrdaringSystem.Models
{
    public class Medicine
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter medicine name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter quantity")]
        //[MinLength(0, ErrorMessage = "Invalid number ! please give positive number")]
        public int Quantity { get; set; }


        [Required(ErrorMessage = "Please select category")]
        public int CategoryId { get; set; }


        public string CategoryName { get; set; }
       


        [Required(ErrorMessage = "Please enter price")]
        public double Price { get; set; }

        public string Image { get; set; }
        public HttpPostedFileBase ImageId { get; set; }


        //public byte[] ImageId { get; set; }


        //public Medicine()
        //{
        //    ImageId = null;

        //}

        
    }
}