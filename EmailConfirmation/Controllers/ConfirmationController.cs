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
        public async Task<IActionResult> Index(string guid, int id)
        {

            var data = await _context.Users.FirstOrDefaultAsync(User => User.Id == id);

            return View(data);
        }
        // GET: Confirmation/Edit/5
        public async Task<IActionResult> Verification(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
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
