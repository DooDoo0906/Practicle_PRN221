using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;

namespace CandidateManagement_LaiDinhThuan.Pages.CandidateProfiles
{
    public class DetailsModel : PageModel
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly BusinessObject.Models.CandidateManagementContext _context;

        public DetailsModel(ICandidateRepository candidateRepository,BusinessObject.Models.CandidateManagementContext context)
        {
            this.candidateRepository = candidateRepository;
            _context = context;
        }

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
            return Page();
        }
    }
}
