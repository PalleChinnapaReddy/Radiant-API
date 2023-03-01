using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Radiant.API.WorkerServices
{
    public class RadiantWorkerService : IHostedService, IDisposable
    {
        private readonly ILogger<RadiantWorkerService> _logger;
        private Timer _timer = null!;
        private HttpClient _httpClient;
        private DateTime startTime;
        private DateTime endTime;
        private readonly IConfiguration _configuration;

        public RadiantWorkerService(ILogger<RadiantWorkerService> logger, IConfiguration configuration)

        {
            _logger = logger;
            _configuration = configuration;
            endTime = DateTime.Now.AddMinutes(-30);
            startTime = endTime.AddMinutes(-5);
            //startTime = new DateTime(2022, 04, 01);
            //endTime = new DateTime(2022, 01, 02);
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");
            _logger.LogInformation($"WorkerUrl:{_configuration["WorkerUrl"]}");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            var parameters = new Dictionary<string, string> {
                { "startTime", startTime.ToString("dd-MMMM-yyyy HH:mm:ss") },
                { "endTime", endTime.ToString("dd-MMMM-yyyy HH:mm:ss") }
            };
            var encodedContent = new FormUrlEncodedContent(parameters);
            using (_httpClient = new HttpClient())
            {
                _logger.LogInformation($"Updating Radiant data ");
                _httpClient.Timeout = TimeSpan.FromMinutes(2);
                var response = await _httpClient.PostAsync(_configuration["WorkerUrl"], encodedContent);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Radiant data update failed");
                }
            }
            startTime = endTime;
            endTime = endTime.AddMinutes(5);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
