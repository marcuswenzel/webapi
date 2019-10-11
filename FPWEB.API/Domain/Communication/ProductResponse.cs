using FPWEB.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPWEB.API.Domain.Communication
{
    public class ProductResponse : BaseResponse
    {
        public Product Product { get; protected set; }

        private ProductResponse(bool success, string message, Product product) : base(success, message)
        {
            this.Product = product;
        }

        public ProductResponse(Product product) : this(true, string.Empty, product)
        { }

        public ProductResponse(string message) : this(false, message, null)
        { }
    }
}
