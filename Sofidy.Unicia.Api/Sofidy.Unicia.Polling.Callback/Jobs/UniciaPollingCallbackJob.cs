using MediatR;
using Microsoft.Extensions.Logging;
using Quartz;
using Sofidy.Unicia.Application.Features.CallbackFeatures.PollingCallback;
using Sofidy.Unicia.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Polling.Callback.Jobs
{
    [DisallowConcurrentExecution]
    internal class UniciaPollingCallbackJob : IJob
    {
        private readonly ILogger<UniciaPollingCallbackJob> _logger;
        private readonly IMediator _mediator;
        private readonly IAckCacheService _ackCacheService;

        public UniciaPollingCallbackJob(ILogger<UniciaPollingCallbackJob> logger, 
                                        IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _mediator.Send(new PollingCallbackRequest(), CancellationToken.None);
        }
    }
}
