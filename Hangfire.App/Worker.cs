using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Hangfire.App
{
    public class Worker : BackgroundService
    {
        private readonly IRecurringJobManager _recurringJobManager;

        public Worker(IRecurringJobManager recurringJobManager)
        {
            _recurringJobManager = recurringJobManager;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _recurringJobManager.AddOrUpdate("jobId", () => Debug.WriteLine("Drugi Test Ziom _________________________________________"), Cron.Minutely);
        }
    }
}
