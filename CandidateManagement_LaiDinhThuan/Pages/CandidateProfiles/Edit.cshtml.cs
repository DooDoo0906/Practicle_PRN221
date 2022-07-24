using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;

namespace CandidateManagement_LaiDinhThuan.Pages.CandidateProfiles
{
    public class EditModel : PageModel
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly BusinessObject.Models.CandidateManagementContext _context;

        public EditModel(ICandidateRepository candidateRepository,BusinessObject.Models.CandidateManagementContext context)
        {
            this.candidateRepository = candidateRepository;
            _context = context;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CandidateProfile = await candidateRepository.GetCandidateById(id);

            if (CandidateProfile == null)
            {
                return NotFound();
            }
           ViewData["PostingId"] = new SelectList(_context.JobPostings, "PostingId", "PostingId");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await candidateRepository.Update(CandidateProfile);
           

            return RedirectToPage("./Index");
        }

       
    }
}
