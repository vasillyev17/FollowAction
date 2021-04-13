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
    public class DepartmentController : Controller
    {
        private readonly AppContext _context;

        public DepartmentController(AppContext context)
        {
            _context = context;
        }

        // GET: Department
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return new JsonResult(await _context.Department.ToListAsync());
        }



        // GET: Department/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new JsonResult("Operation failed");
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.idDepartment == id);
            if (department == null)
            {
                return new JsonResult("Operation failed");
            }

            return new JsonResult(department);
        }


     

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return new JsonResult("Action added successfully!");
            }
            return new JsonResult("Operation failed");
        }


     


        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] Department department)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.idDepartment))
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
            if (DepartmentExists(id))
            {

                var department = await _context.Department.FindAsync(id);
                _context.Department.Remove(department);
                await _context.SaveChangesAsync();
                return new JsonResult("Success");
            }
            else
            {
                return new JsonResult("Operation failed");
            }
        }

        private bool DepartmentExists(int id)
        {
            return _context.Department.Any(e => e.idDepartment == id);
        }
    }
}
