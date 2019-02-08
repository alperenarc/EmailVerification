using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace EmailConfirmation.Models
{
    public class UserViewModel : ViewViewComponentResult
    {
        public List<User> users { get; set; }
    }
}