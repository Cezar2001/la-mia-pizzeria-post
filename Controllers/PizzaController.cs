using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public static ListaPizze Pizze = null;
        public IActionResult Index()
        {
            if (Pizze == null)
            {
                Pizze = new ListaPizze();
                Pizza quattroFormaggi = new Pizza(0, "Pizza Quattro Formaggi", "pomodoro , mozzarella campana , basilico", "/Img/pizza-quattro-formaggi.jfif", 3);
                Pizza capricciosa = new Pizza(1, "Pizza Capriciosa", "Che soddisfa ogni capriccio", "/Img/pizza-quattro-stagioni.jfif", 4);
                Pizza salsicciaPatate = new Pizza(2, "Pizza Margherita", "salsiccia , patate , mozzarella capana", "/Img/pizza-margherita.jfif", 5);
                Pizza marinara = new Pizza(3, "Pizza Marinara", "Grande classico", "/Img/pizza-margherita.jfif", 3);
                Pizza quattroStagioni = new Pizza(4, "Pizza Quattro Stagioni", "La quattro Stagioni", "/Img/pizza-quattro-stagioni.jfif", 4);
                Pizze.ListaDiPizze.Add(quattroFormaggi);
                Pizze.ListaDiPizze.Add(capricciosa);
                Pizze.ListaDiPizze.Add(salsicciaPatate);
                Pizze.ListaDiPizze.Add(marinara);
                Pizze.ListaDiPizze.Add(quattroStagioni);
            }

            return View(Pizze);
        }

        public IActionResult Show(int id)
        {
            return View("Show", Pizze.ListaDiPizze[id]);
        }

        public IActionResult CreaFormPizza()
        {
            Pizza NuovaPizza = new Pizza()
            {
                Id = 0,
                Nome = "",
                Descrizione = "",
                sFoto = "",
                Prezzo = 1,
            };
            return View(NuovaPizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreaSchedaPizza(Pizza DatiPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("CreaFormPizza", DatiPizza);
            }

            
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\File");
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FileInfo fileInfo = new FileInfo(DatiPizza.Foto.FileName);
            string fileName = DatiPizza.Nome + fileInfo.Extension;
            string fileNameWithPath = Path.Combine(path, fileName);
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                DatiPizza.Foto.CopyTo(stream);
            }

            Pizza nuovaPizza = new Pizza()
            {
                Id = DatiPizza.Id,
                Nome = DatiPizza.Nome,
                Descrizione = DatiPizza.Descrizione,
                sFoto = "/File/" + fileName,
                Prezzo = DatiPizza.Prezzo,
            };

            Pizze.ListaDiPizze.Add(nuovaPizza);
            return View(nuovaPizza);
        }
    }
}
