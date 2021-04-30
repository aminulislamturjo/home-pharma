using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlinePharmacyOrdaringSystem.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }

        [Required]
        public string PharmacyName { get; set; }

        [Required]
        public string Owner { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ContactNo { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string FindLocation { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int PharmUserId { get; set; }

    }
}