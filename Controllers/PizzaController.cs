using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            Pizza quattroFormaggi = new Pizza("Pizza Quattro Formaggi", "pomodoro , mozzarella campana , basilico", "/Img/pizza-quattro-formaggi.jfif", 3);
            Pizza capricciosa = new Pizza("Pizza Capriciosa", "Che soddisfa ogni capriccio", "/Img/pizza-quattro-stagioni.jfif", 4);
            Pizza salsicciaPatate = new Pizza("Pizza Margherita", "salsiccia , patate , mozzarella capana", "/Img/pizza-margherita.jfif", 5);
            Pizza marinara = new Pizza("Pizza Marinara", "Grande classico", "/Img/pizza-margherita.jfif", 3);
            Pizza quattroStagioni = new Pizza("Pizza Quattro Stagioni", "La quattro Stagioni", "/Img/pizza-quattro-stagioni.jfif", 4);
            ListaPizze pizze = new ListaPizze();
            pizze.ListaDiPizze.Add(quattroFormaggi);
            pizze.ListaDiPizze.Add(capricciosa);
            pizze.ListaDiPizze.Add(salsicciaPatate);
            pizze.ListaDiPizze.Add(marinara);
            pizze.ListaDiPizze.Add(quattroStagioni);
            return View(pizze);
        }

        [HttpGet]
        public IActionResult CreaFormPizza()
        {
            Pizza TempPizza = new Pizza()
            {
                Id = 0,
                Nome = "",
                Descrizione = "",
                Foto = "",
                Prezzo = 0,
            };
            return View(TempPizza);
        }
    }
}
