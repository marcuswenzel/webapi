using FPWEB.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPWEB.API.Domain.Communication
{
    public class CustomerResponse : BaseResponse
    {
        public Customer Customer { get; protected set; }

        private CustomerResponse(bool success, string message, Customer customer) : base(success, message)
        {
            this.Customer = customer;
        }

        public CustomerResponse(Customer customer) : this(true, string.Empty, customer)
        { }

        public CustomerResponse(string message) : this(false, message, null)
        { }
    }
}
