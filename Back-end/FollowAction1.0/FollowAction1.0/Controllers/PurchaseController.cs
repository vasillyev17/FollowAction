using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FollowAction1._0.Models;

namespace FollowAction1._0.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PurchaseController : Controller
    {
        private readonly AppContext _context;

        public PurchaseController(AppContext context)
        {
            _context = context;
        }


       

        // GET: Purchase
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return new JsonResult(await _context.Purchase.ToListAsync());
        }



        // GET: Purchase/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new JsonResult("Operation failed");
            }

            var purchase = await _context.Purchase
                .FirstOrDefaultAsync(m => m.idPurchase == id);
            if (purchase == null)
            {
                return new JsonResult("Operation failed");
            }

            return new JsonResult(purchase);
        }

    

        // POST: Purchase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchase);
                await _context.SaveChangesAsync();
                return new JsonResult("Action added successfully!");
            }
            return new JsonResult("Operation failed");
        }

     

       

        // POST: Purchase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] Purchase purchase)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.idPurchase))
                    {
                        return new JsonResult("Operation failed");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return new JsonResult("Success");
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (PurchaseExists(id))
            {

                var purchase = await _context.Purchase.FindAsync(id);
                _context.Purchase.Remove(purchase);
                await _context.SaveChangesAsync();
                return new JsonResult("Success");
            }
            else
            {
                return new JsonResult("Operation failed");
            }
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.idPurchase == id);
        }
    }
}
