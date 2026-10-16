using HW_4_WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_4_WEB.Controllers
{
   
        public class CarsController : Controller
        {
            private static List<Car> availableCars = new List<Car>
            {
                new Car { Id = 1, Name = "Alto", PricePerDay = 3000 },
                new Car { Id = 2, Name = "Corolla", PricePerDay = 6000 },
                new Car { Id = 3, Name = "Civic", PricePerDay = 8000 }
            };
            private static List<Car> bookedCars = new List<Car>();
            
            public IActionResult Index()
            {
                return View(availableCars);
            }

            [HttpPost]
            public IActionResult Book(int id)
            {
                var carToBook = availableCars.FirstOrDefault(c => c.Id == id);
                if (carToBook != null)
                {
                    availableCars.Remove(carToBook);
                    bookedCars.Add(carToBook);
                    return RedirectToAction("BookedCars");
                }
               
                return RedirectToAction("Index");
            }

           
            public IActionResult BookedCars()
            {
                return View(bookedCars);
            }
       
        
    }
}
