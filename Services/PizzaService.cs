using RazorPagesPizza.Models;

namespace RazorPagesPizza.Services;
public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
                {
                    new Pizza { Id = 1, Name = "Moda Italiana", Price=20.00M, Size=PizzaSize.Medio, ContainsGluten = true },
                    new Pizza { Id = 2, Name = "Verde Vegano", Price=15.00M, Size=PizzaSize.Pequeno, ContainsGluten = false }
                };
    }
    public static List<Pizza> GetAll() => Pizzas;
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);
    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }
    public static void Delete(int id)
    {
        Pizza? pizza = Get(id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }
    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }
}