﻿using System;
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
        public async Task OnGetAsync()
        {
        }
    }
}
