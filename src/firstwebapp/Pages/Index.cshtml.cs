using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace firstwebapp.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public IndexModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task OnGetAsync()
        {
            var user = await _userManager.FindByIdAsync("74b6df55-6f27-4614-bcd5-444868a4e582");
            await _userManager.AddToRoleAsync(user, "User");
            await _userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
