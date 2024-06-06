﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaOrderAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId {  get; set; }
        public DateTime OrderDateTime { get; set; }= DateTime.Now;
        public decimal totalOrderPrice { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
    }
}
