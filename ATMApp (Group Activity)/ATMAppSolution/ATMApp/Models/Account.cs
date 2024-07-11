using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ATMApp.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        public decimal Balance { get; set; }
    }
}
