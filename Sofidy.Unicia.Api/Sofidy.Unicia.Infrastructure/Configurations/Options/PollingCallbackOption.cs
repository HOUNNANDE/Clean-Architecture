using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Infrastructure.Configurations.Options
{
    public record PollingCallbackOption
    {
        public const string Name = "PollingCallbacks";

        public string Host { get; set; }

        public Endpoints Endpoints { get; set; }
    }

    public record Endpoints
    {
        public string Callback { get; set; }
    }
}
