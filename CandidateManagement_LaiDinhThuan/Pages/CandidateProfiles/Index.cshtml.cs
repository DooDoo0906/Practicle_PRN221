using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using DataAccess;

namespace CandidateManagement_LaiDinhThuan.Pages.CandidateProfiles
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly IConfiguration configuration;

        public IndexModel(IConfiguration configuration, ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
            this.configuration = configuration;
        }

        public string NameSort { get; set; }
        public string CateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<CandidateProfile> Candidates { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
           
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CateSort = sortOrder == "Cate" ? "cate_desc" : "Cate";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<CandidateProfile> empQuery = candidateRepository.GetCandidates();


            if (!String.IsNullOrEmpty(searchString))
            {
                empQuery = empQuery.Where(s => s.Fullname.Contains(searchString) || s.Birthday.ToString().Contains(searchString));
            }
            empQuery = sortOrder switch
            {
                "name_desc" => empQuery.OrderByDescending(s => s.Fullname),
                "Cate" => empQuery.OrderBy(s => s.CandidateId),
                "cate_desc" => empQuery.OrderByDescending(s => s.CandidateId),
                _ => empQuery.OrderBy(s => s.Fullname),
            };
            var pageSize = configuration.GetValue("PageSize", 3);
            Candidates = await PaginatedList<CandidateProfile>.CreateAsync(
                empQuery.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
