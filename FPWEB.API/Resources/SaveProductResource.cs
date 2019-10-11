using FPWEB.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FPWEB.API.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]        
        public short QuantityInPackage { get; set; }

        [Required]
        public string UnitOfMeasurement { get; set; }

        //[Required]
        public Category Category { get; set; }

        //[Required]
        public int IdCategory { get; set; }


    }
}
