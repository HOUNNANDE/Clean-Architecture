using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Sofidy.Unicia.Infrastructure.Extensions;
using Sofidy.Unicia.Polling.Callback.Common;
using Sofidy.Unicia.Polling.Callback.Jobs;
using Sofidy.Unicia.Polling.Callback.Triggers;
using System;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Polling.Callback
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            IHost builder = Host.CreateDefaultBuilder(args)
                                .UseAppSettings()
                                .ConfigureServices((Action<HostBuilderContext, IServiceCollection>)((context, services) =>
                                {
                                    services.AddQuartz((Action<IServiceCollectionQuartzConfigurator>)(q =>
                                    {
                                        q.UseMicrosoftDependencyInjectionJobFactory();

                                        q.AddJob<UniciaPollingCallbackJob>(JobConstants.UniciaPollingCallback, configure =>
                                        {
                                            configure.WithIdentity(JobConstants.UniciaPollingCallback);
                                        });

                                        q.AddTrigger(UniciaPoolingTrigger.CreateTrigger);
                                    }));

                                    services.AddQuartzHostedService(opt => opt.WaitForJobsToComplete = true);

                                    services.ConfigureServices(context.Configuration);
                                })).Build();

            await builder.RunAsync();
        }
    }
}