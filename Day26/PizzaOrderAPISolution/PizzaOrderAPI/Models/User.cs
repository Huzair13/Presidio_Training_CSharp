
using System.ComponentModel.DataAnnotations;

namespace PizzaOrderAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNum { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string? Role { get; set; } = "User";

    }
}
