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
    public class BuyerMovementController : Controller
    {
        private readonly AppContext _context;

        public BuyerMovementController(AppContext context)
        {
            _context = context;
        }

        // GET: BuyerMovement
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return new JsonResult(await _context.BuyerMovement.ToListAsync());
        }

        // GET: BuyerMovement/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new JsonResult("Operation failed");
            }

            var buyerMovement = await _context.BuyerMovement
                .FirstOrDefaultAsync(m => m.idMovement == id);
            if (buyerMovement == null)
            {
                return new JsonResult("Operation failed");
            }

            return new JsonResult(buyerMovement);
        }

     

        // POST: BuyerMovement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BuyerMovement buyerMovement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyerMovement);
                await _context.SaveChangesAsync();
                return new JsonResult("Action added successfully!");
            }
            return new JsonResult("Operation failed");
        }




        // POST: BuyerMovement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] BuyerMovement buyerMovement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyerMovement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerMovementExists(buyerMovement.idMovement))
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
            if (BuyerMovementExists(id))
            {

                var buyerMovement = await _context.BuyerMovement.FindAsync(id);
                _context.BuyerMovement.Remove(buyerMovement);
                await _context.SaveChangesAsync();
                return new JsonResult("Success");
            }
            else
            {
                return new JsonResult("Operation failed");
            }
        }


        private bool BuyerMovementExists(int id)
        {
            return _context.BuyerMovement.Any(e => e.idMovement == id);
        }
    }
}
