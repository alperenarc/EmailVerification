using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmailConfirmation.Models;

namespace EmailConfirmation.Controllers
{
    public class ConfirmationController : Controller
    {
        private readonly DataContext _context;

        public ConfirmationController(DataContext context)
        {
            _context = context;
        }

        // GET: Confirmation
        public async Task<IActionResult> Index(string guidcode, int id)
        {
            guidcode = HttpContext.Request.Query["guidcode"];

            var data = await _context.Users.ToListAsync();

            return View(data);
        }
        // GET: Confirmation/Edit/5
        public async Task<IActionResult> Verification(string guidcode)
        {
            guidcode = HttpContext.Request.Query["guidcode"];
            if (guidcode == null)
            {
                return NotFound();
            }

            //var user = await _context.Users.FindAsync(guidcode);
            var user = await  _context.Users.FirstOrDefaultAsync(p=>p.GuideCode == guidcode);
            user.ConfirmState = true;
            _context.Update(user);
            await _context.SaveChangesAsync();

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


    }
}
