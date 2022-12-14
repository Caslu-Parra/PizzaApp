using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPizza.Models;
using RazorPagesPizza.Services;

namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {
        [BindProperty]
        public Pizza NewPizza { get; set; } = new();
        public List<Pizza> pizzas = new();
        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }
        public IActionResult OnPostUpdate(int id)
        {
            Pizza? pizza = PizzaService.Get(id);
            if (pizza != null)
            {
                pizza.Price += 5;
                Array sizes = Enum.GetValues(typeof(PizzaSize));
                pizza.Size = (PizzaSize)sizes.GetValue(new Random().Next(sizes.Length));
                PizzaService.Update(pizza);
            }
            return RedirectToAction("Get");
        }
    }
}