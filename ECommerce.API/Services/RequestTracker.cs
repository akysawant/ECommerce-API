namespace ECommerce.API.Services
{
    public class RequestTracker
    {
        public Guid Id { get; } = Guid.NewGuid();

        public RequestTracker()
        {
            Console.WriteLine($"RequestTracker created : {Id}");
        }
    }
}
