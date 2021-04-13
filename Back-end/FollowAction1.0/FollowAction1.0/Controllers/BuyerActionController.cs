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
    public class BuyerActionController : Controller
    {
        private readonly AppContext _context;

        public BuyerActionController(AppContext context)
        {
            _context = context;
        }

        // GET: BuyerAction
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return new JsonResult(await _context.BuyerAction.ToListAsync());
        }

        // GET: BuyerAction/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new JsonResult("Operation failed");
            }

            var buyerAction = await _context.BuyerAction
                .FirstOrDefaultAsync(m => m.idAction == id);
            if (buyerAction == null)
            {
                return new JsonResult("Operation failed");
            }

            return new JsonResult(buyerAction);
        }

        // POST: BuyerAction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BuyerAction buyerAction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyerAction);
                await _context.SaveChangesAsync();
                return new JsonResult("Action added successfully!");
            }
            return new JsonResult("Operation failed");
        }

        // PUT: BuyerAction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Edit(int id,[FromBody] BuyerAction buyerAction)
        { 
            if (ModelState.IsValid)
            {
                try
                {
                    buyerAction.idAction = id;
                    _context.Update(buyerAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerActionExists(buyerAction.idAction))
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

        // DELETE: BuyerAction/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (BuyerActionExists(id))
            {

                var buyerAction = await _context.BuyerAction.FindAsync(id);
                _context.BuyerAction.Remove(buyerAction);
                await _context.SaveChangesAsync();
                return new JsonResult("Success");
            }
            else
            {
                return new JsonResult("Operation failed");
            }
        }

        private bool BuyerActionExists(int id)
        {
            return _context.BuyerAction.Any(e => e.idAction == id);
        }
    }
}
