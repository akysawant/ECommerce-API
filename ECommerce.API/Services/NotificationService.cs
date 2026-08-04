namespace ECommerce.API.Services
{
    public class NotificationService
    {
        public void SendEmial(string email)
        {
            Console.WriteLine($"Email Sent to {email}");
        }

        public void SentSms(string mobile)
        {
            Console.WriteLine($"SMS Sent to {mobile}");
        }
    }
}
