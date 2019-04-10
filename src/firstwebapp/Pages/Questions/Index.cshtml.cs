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
using firstwebapp.ViewModel;

namespace firstwebapp.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<QuestionViewModel> Question { get; set; }
        public async Task OnGetAsync()
        {
            Question = _context.Questions.Include(d => d.Vote).Select(a =>
                new QuestionViewModel() { VoteCount = a.Vote.Count(), dumbQuestion = a.dumbQuestion, ID = a.ID, Submitter = a.Submitter }
            ).AsEnumerable();

        }
    }

}


