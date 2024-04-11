using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Common.Exceptions
{
    public class OperationException : Exception
    {
        public OperationException(string message) : base(message) { }
    }
}
