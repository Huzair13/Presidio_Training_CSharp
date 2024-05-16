using System.ComponentModel.DataAnnotations;

namespace PizzaOrderAPI.Models
{
    public enum PizzaSize
    {
        Small,
        Medium,
        Large
    }

    public enum CrustType
    {
        Thin,
        Thick,
        Stuffed
    }

    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PizzasInStock { get; set; }
        public string PizzaImage { get; set; }
        public PizzaSize size { get; set; }
        public CrustType crustType { get; set; }
        public bool isVeg {  get; set; }
        public bool isPizzaAvailable {  get; set; }

    }
}
