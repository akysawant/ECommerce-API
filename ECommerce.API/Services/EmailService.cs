using ECommerce.API.Configurations;
using Microsoft.Extensions.Options;

namespace ECommerce.API.Services
{
    public class EmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }
    }
}
