using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPWEB.API.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

        public int IdCategory { get; set; }
        public Category Category { get; set; }
    }
}
