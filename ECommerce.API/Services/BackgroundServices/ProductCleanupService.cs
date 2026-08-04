using Microsoft.Extensions.Caching.Memory;

namespace ECommerce.API.Services.BackgroundServices
{
    public class ProductCleanupService : BackgroundService
    {
        private readonly ILogger<ProductCleanupService> _logger;

        public ProductCleanupService(ILogger<ProductCleanupService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    _logger.LogInformation("Backgroud service Running at {Time}", DateTime.Now);

            //    await Task.Delay(
            //        TimeSpan.FromSeconds(10),
            //        stoppingToken);
            //}
        }
    }
}
