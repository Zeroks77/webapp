using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using firstwebapp.Models;
using firstwebapp.Data;

namespace firstwebapp.Pages.Questions
{
    public class Vote : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Vote(ApplicationDbContext context)
        {
            _context = context;
        }      
         [BindProperty]
        public Question Frage { get; set; }
        public IList<Question> Question { get;set; }
        public void OnGet(int? id)
        {
            Frage = _context.Questions.FirstOrDefault(m => m.ID == id);
        }

        public IActionResult OnPost()
        {
            // do something with username and password
            Frage.Vote ++;

            // or you can redirect to another page
            return RedirectToPage("./Index");
        }
    }
}