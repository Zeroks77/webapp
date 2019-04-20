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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace firstwebapp.Pages.Questions
{

    [Authorize(Roles = "User")]
    public class Vote : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Vote(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager
            )
        {
            _context = context;
            UserManager = userManager;
        }

        public Question Question { get; set; }
        public int? ID { get; set; }
        public bool UpvoteExist = false;
        public int VoteCounter = 0;
        public UserManager<IdentityUser> UserManager { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ID = id;
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.Questions.FirstOrDefaultAsync(m => m.ID == id);
            try
            {
                VoteCounter = Question.Vote.Count();
            }
            catch (Exception)
            {
                VoteCounter = 0;
            } 

            if (Question == null)
            {
                return NotFound();
            }
            if (await _context.Votes.FindAsync(id) == null)
            {
                UpvoteExist = true;
            } 
            return Page();
        }        
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            ID = id;
            int Id;
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                Id = id.Value;
            }
            var user = await UserManager.GetUserAsync(HttpContext.User);
            _context.Votes.Add(new Votes() { QuestionId = Id, UserId = user.Id });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!QuestionExists(Question.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (DbUpdateException ex)
            {
                if(ex.InnerException.Message.Contains("duplicate key"))
                {
                    Question = _context.Questions.FirstOrDefault(d => d.ID == Id);
                    _context.Votes.Remove(_context.Votes.FirstOrDefault(d=> d.ID == Id));
                    return Page();
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
            return RedirectToPage("./Index");
        }
        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.ID == id);
        }
    }
}