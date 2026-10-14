using Microsoft.AspNetCore.Mvc;
using HW4.Models;

namespace HW4.Controllers
{
    public class CarController : Controller
    {
        private static List<Car> availableCars = new List<Car>
        {
            new Car(1, "Alto", 3000),
            new Car(2, "Corolla", 6000),
            new Car(3, "Civic", 8000)
        };

        private static List<Car> bookedCars = new List<Car>();



        public IActionResult Index()
        {
            return View(availableCars);
        }

        [HttpPost]
        public IActionResult Book(int id)
        {
            var carToBook = availableCars.FirstOrDefault(c => c.id == id);
            if (carToBook != null)
            {
                availableCars.Remove(carToBook);
                bookedCars.Add(carToBook);
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Booked()
        {
            return View(bookedCars);
        }

    }
}
