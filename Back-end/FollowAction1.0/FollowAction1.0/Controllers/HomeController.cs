using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FollowAction1._0.Models;
using Microsoft.EntityFrameworkCore;

namespace FollowAction1._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppContext _context;

        public HomeController(ILogger<HomeController> logger, AppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPut]
        public IActionResult BuyerInterestPercent(int id)
        {
            var reactionCoefficient = 0;
            var movements = _context.BuyerMovement.FromSqlRaw("Select * from BuyerMovement where idBuyer = "+id+"").ToList();
            string[] arr = new string[movements.Count];
            for (int i = 0; i < movements.Count; i++)
            {
                arr[i] = movements[i].EndPoint;
            }
            var sectionCount = arr.Length;
            var reactions = _context.BuyerAction.FromSqlRaw("Select  * from buyerAction where idBuyer = "+id+" limit 1").ToList();
            string[] arr2 = new string[reactions.Count];
            for (int i = 0; i < reactions.Count; i++)
            {
                arr2[i] = reactions[i].actionType;
            }
            var reactionType = arr2[0];
            if (reactionType == "Positive") {
                reactionCoefficient = 10;
            } else if (reactionType == "Neutral")
            {
                reactionCoefficient = 5;
            } else if (reactionType == "Negative")
            {
                reactionCoefficient = 0;
            }
            Console.WriteLine(sectionCount);
            Console.WriteLine(reactionCoefficient);
            var buyerInterestPercent = sectionCount * reactionCoefficient * 5;
            return new JsonResult("BuyerInterestPercent:"+buyerInterestPercent+"");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
