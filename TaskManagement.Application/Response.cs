using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; } = null!;
        public object? Result { get; set; }
    }
}
