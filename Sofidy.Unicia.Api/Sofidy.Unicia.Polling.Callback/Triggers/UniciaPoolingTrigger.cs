using Quartz;
using Sofidy.Unicia.Polling.Callback.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Polling.Callback.Triggers
{
    internal class UniciaPoolingTrigger
    {
        private static readonly string TRIGGER_NAME = "UniciaPoolingTrigger_EverySecond";
        private static readonly string TRIGGER_GROUPNAME = "Unicia";
        private static readonly JobKey JOB_KEY = JobConstants.UniciaPollingCallback;
        private static readonly int TRIGGER_INTERVAL_SECONDS = 10;

        internal static void CreateTrigger(ITriggerConfigurator configurator) =>
            configurator.WithIdentity(UniciaPoolingTrigger.TRIGGER_NAME,
                                      UniciaPoolingTrigger.TRIGGER_GROUPNAME)
                        .ForJob(UniciaPoolingTrigger.JOB_KEY).StartNow()
                        .WithSimpleSchedule(schedulerBuilder =>
                        {
                            schedulerBuilder.WithIntervalInSeconds(UniciaPoolingTrigger.TRIGGER_INTERVAL_SECONDS)
                                            .RepeatForever();
                        });
                             
    }
}
