using System.ComponentModel.DataAnnotations;

namespace RazorPagesPizza.Models;

public class Pizza
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    public PizzaSize Size { get; set; }
    public bool ContainsGluten { get; set; }

    [Range(0.01, 9999.99)]
    public decimal Price { get; set; }
}

public enum PizzaSize { Pequeno, Medio, Grande }