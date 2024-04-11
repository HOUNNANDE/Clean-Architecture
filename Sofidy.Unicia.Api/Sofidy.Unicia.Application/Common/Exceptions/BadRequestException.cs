using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public string[] Errors { get; set; } = new string[0];

        public BadRequestException(string message) : base(message)
        { 
        }

        public BadRequestException(string[] errors)
        {
            Errors = errors;
        }
    }
}
