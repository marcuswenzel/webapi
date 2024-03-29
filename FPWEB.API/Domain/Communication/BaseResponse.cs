﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FPWEB.API.Domain.Communication
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponse(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }
    }
}
