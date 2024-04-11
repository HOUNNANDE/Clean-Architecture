using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Common.Exceptions
{
    public class OperationArgumentNullException : ArgumentNullException
    {
        public OperationArgumentNullException(string message) : base($"An object could not be found: {message}" ) { }
    }
}
