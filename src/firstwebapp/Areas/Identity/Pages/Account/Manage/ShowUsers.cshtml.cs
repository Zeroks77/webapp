using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using firstwebapp.Models;
using firstwebapp.Data;
using firstwebapp.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace firstwebapp.Areas.Identity.Pages.Account.Manage
{
    public class ShowUserModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ShowUserModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ShowUserViewModel> Users { get; set; }

        public async Task OnGetAsync()
        {
             Users = _context.Users.Select(a =>
             new ShowUserViewModel() { ID = a.Id, EMail = a.Email, UserName = a.UserName, FragenEingereicht = _context.Questions.Where(b => b.EingereichtVonID == a.Id).Count(), VotesGegeben = _context.Votes.Where(b => b.UserId == a.Id).Count() }) ;
            
        }
    }
}
