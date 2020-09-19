using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationAndError.Models
{
    public class Error
    {
        public string Message { get; set; } = string.Empty;
        public string Parameter { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}