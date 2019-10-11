using FPWEB.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPWEB.API.Domain.Communication
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; protected set; }

        private CategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            this.Category = category;
        }

        public CategoryResponse(Category category) : this(true, string.Empty, category)
        { }

        public CategoryResponse(string message) : this(false, message, null)
        { }
    }
}
