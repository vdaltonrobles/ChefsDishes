using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;


namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefDishContext dbContext;

        public HomeController(ChefDishContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(dish=>dish.CreatedDishes).ToList();
            return View(AllChefs);
        }

        [HttpGet("new")]
        public IActionResult AddChefForm()
        {
            return View();
        }

        [HttpPost("processNewChef")]
        public IActionResult ProcessNewChef(Chef newChef)
        {
            if (ModelState.IsValid)
            {
                System.Console.WriteLine($"{newChef.FirstName} | {newChef.LastName}***************************************");
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddChefForm");
            }
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(chef=>chef.Creator).ToList();
            return View(AllDishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult AddDishForm()
        {
            List<Chef> ListOfChefs = dbContext.Chefs.Include(dish=>dish.CreatedDishes).ToList();
            ViewBag.All = ListOfChefs;
            return View();
        }

        [HttpPost("processNewDish")]
        public IActionResult ProcessNewDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                System.Console.WriteLine($"{newDish.Name} | {newDish.Calories}***************************************");
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                List<Chef> ListOfChefs = dbContext.Chefs.Include(dish=>dish.CreatedDishes).ToList();
                ViewBag.All = ListOfChefs;
                return View("AddDishForm");
            }
        }
    }
}

