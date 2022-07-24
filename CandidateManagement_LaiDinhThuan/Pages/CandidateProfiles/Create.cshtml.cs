using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;

namespace CandidateManagement_LaiDinhThuan.Pages.CandidateProfiles
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.Models.CandidateManagementContext _context;
        private readonly ICandidateRepository candidateRepository;
        public CreateModel(ICandidateRepository candidateRepository, BusinessObject.Models.CandidateManagementContext context)
        {
            this.candidateRepository = candidateRepository;
            _context = context;
        }

        public IActionResult OnGet()
        {

            ViewData["PostingId"] = new SelectList(_context.JobPostings, "PostingId", "PostingId");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await candidateRepository.Insert(CandidateProfile);


            return RedirectToPage("./Index");
        }
    }
}
