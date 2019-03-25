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
        public List<int> VoteCounter = new List<int>();

        public async Task OnGetAsync()
        {
            Question = await _context.Questions                
                .ToListAsync();
            IQueryable<Question> Upvotes = from s in _context.Questions
                                    select s;
            Upvotes = Upvotes.OrderByDescending(a => a.Vote.Count());
            foreach (var item in Question)
            {
                try
                {
                    VoteCounter.Add(item.Vote.Count());
                }
                catch (Exception)
                {
                    VoteCounter.Add(0);

                }

            }


            Question = Upvotes.ToList();
        }


    }
}
