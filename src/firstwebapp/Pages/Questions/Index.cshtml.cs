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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Question> Question { get; set; }
        public List<int> VoteCounter = new List<int>();
        public async Task OnGetAsync()
        {
            Question = await _context.Questions.ToListAsync();
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
        }
    }

}


