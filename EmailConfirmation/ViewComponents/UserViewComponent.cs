using EmailConfirmation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailConfirmation.ViewComponents
{
    public class UserViewComponent :ViewComponent
    {
        private readonly DataContext _context;

        public UserViewComponent(DataContext context)
        {
            _context = context;
        }
        public ViewViewComponentResult Invoke(string guidcode)
        {
            guidcode = HttpContext.Request.Query["guidcode"];
            return View(new UserViewModel
            {
                users = _context.Users.Where(s=> s.GuideCode.Contains(guidcode)).ToList()
            });
        }
    }

    
}
