using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using firstwebapp.Models;
using firstwebapp.Data;

namespace firstwebapp.Pages.Questions
{
    public class RankingModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RankingModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Question> Question { get;set; }

        public async Task OnGetAsync()
        {
           IQueryable<Question> Upvotes = from s in _context.Questions
                                    select s;
            Upvotes = Upvotes.OrderByDescending(a => a.Vote);

            Question = Upvotes.ToList();
        }


    }
}
