using ECommerce.API.Entities;
using ECommerce.API.Enum;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Customer;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}       
