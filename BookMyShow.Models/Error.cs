﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Models
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
