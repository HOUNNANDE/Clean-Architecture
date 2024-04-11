using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Features.CallbackFeatures.PollingCallback
{
    internal record PollingCallbackResponse
    {
        public List<Guid> Success { get; set; }
        public List<Guid> Error { get; set; }
    }
}
