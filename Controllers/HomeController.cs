using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private DishsContext dbContext;

        public HomeController(DishsContext context)
        {
            dbContext = context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {

            List<Dish> AllDishes = dbContext.Dishes.OrderByDescending(what => what.CreatedAt).ToList();
          
            
            return View(AllDishes);
        }

        [Route("new")]
        [HttpGet]
        public IActionResult NewDish()
        {
            return View();
        }

        [Route("process")]
        [HttpPost]
        public IActionResult Process(Dish newdish)
        {
            if (!ModelState.IsValid)
            {
                return View("Newdish");
            }
            else
            {
                dbContext.Dishes.Add(newdish);
                dbContext.SaveChanges();
                return Redirect("/"); 
            }
        }

        [Route("{dishId}")]
        [HttpGet]
        public IActionResult ViewDish(int dishId)
        {
            Dish ThisDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            return View(ThisDish);
        }

        [Route("delete/{dishId}")]
        [HttpGet]
        public IActionResult DeleteDish(int dishId)
        {
            Dish ThisDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            dbContext.Dishes.Remove(ThisDish);
            dbContext.SaveChanges();
            return Redirect("/");
        }

        [Route("edit/{dishId}")]
        [HttpGet]
        public IActionResult EditDish(int dishId)
        {
            Dish ThisDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
           
            return View(ThisDish);
        }

        [Route("Edit")]
        [HttpPost]
        public IActionResult Edit(Dish editdish)
        {
            if (!ModelState.IsValid)
            {
                return View("EditDish",editdish);
            }
            else
            {
                Dish ThisDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == editdish.DishId);
                Console.WriteLine(editdish.DishId);
                Console.WriteLine("editdish "+editdish.DishName);
                Console.WriteLine("thisdish " + ThisDish.DishName);
                ThisDish.DishName = editdish.DishName;
                ThisDish.ChefName = editdish.ChefName;
                ThisDish.Calories = editdish.Calories;
                ThisDish.Tasiness = editdish.Tasiness;
                ThisDish.Description = editdish.Description;
                // Console.WriteLine("after modify"+ThisDish.DishId +ThisDish.DishName);
                ThisDish.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return Redirect("/");
            }
        }

    }
}
