using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using firstwebapp.Models;
using firstwebapp.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

namespace firstwebapp.Pages.Questions
{

    [Authorize(Roles = "User")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<IdentityUser> usermanager)
        {
            _context = context;
            _userManager = usermanager;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Question Question { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var _user = await _userManager.FindByNameAsync(User.Identity.Name);
            Question.EingereichtVonID = _user.Id;
            _context.Questions.Add(Question);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}