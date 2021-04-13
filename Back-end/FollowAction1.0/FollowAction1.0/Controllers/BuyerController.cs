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
    public class BuyerController : Controller
    {
        private readonly AppContext _context;

        public BuyerController(AppContext context)
        {
            _context = context;
        }
        [HttpGet]
        // GET: Buyer
        public async Task<IActionResult> Index()
        {
            return new JsonResult(await _context.Buyer.ToListAsync());
        }

        // GET: Buyer/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new JsonResult("Operation failed");
            }

            var buyer = await _context.Buyer
                .FirstOrDefaultAsync(m => m.idBuyer == id);
            if (buyer == null)
            {
                return new JsonResult("Operation failed");
            }

            return new JsonResult(buyer);
        }

        // POST: Buyer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyer);
                await _context.SaveChangesAsync();
                return new JsonResult("Action added successfully!");
            }
            return new JsonResult("Operation failed");
        }

        // POST: Buyer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerExists(buyer.idBuyer))
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
            if (BuyerExists(id))
            {

                var buyer = await _context.Buyer.FindAsync(id);
                _context.Buyer.Remove(buyer);
                await _context.SaveChangesAsync();
                return new JsonResult("Success");
            }
            else
            {
                return new JsonResult("Operation failed");
            }
        }

        private bool BuyerExists(int id)
        {
            return _context.Buyer.Any(e => e.idBuyer == id);
        }

    }
}
