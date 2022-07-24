using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateManagement_LaiDinhThuan.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository accountUserRepository;

        public IndexModel(IAccountRepository accountUserRepository)
        {
            this.accountUserRepository = accountUserRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("role");
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("name");
            return Page();
        }
        [BindProperty]

        public string Email { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Password can not be empty.")]

        public string Password { get; set; }
        public string msg { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
            Hraccount user = await accountUserRepository.GetAccount(Email, Password);
            if (user == null)
            {
                msg = "You are not allow to do this function";
                return Page();
            }
            HttpContext.Session.SetInt32("role", value: (int)user.MemberRole);
            HttpContext.Session.SetString("email", Email);
            HttpContext.Session.SetString("name", user.FullName);

            return RedirectToPage("/CandidateProfiles/Index");
        }
    }
}
