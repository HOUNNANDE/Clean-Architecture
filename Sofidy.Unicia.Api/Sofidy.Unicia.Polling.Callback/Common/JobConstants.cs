using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Polling.Callback.Common
{
    internal class JobConstants
    {
        public static readonly JobKey UniciaPollingCallback = new JobKey(nameof(UniciaPollingCallback), "Unicia");
    }
}
