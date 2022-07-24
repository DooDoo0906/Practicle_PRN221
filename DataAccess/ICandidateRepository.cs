using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ICandidateRepository
    {
        IQueryable<CandidateProfile> GetCandidates();
        Task<CandidateProfile> GetCandidateById(string id);
        Task Insert(CandidateProfile item);
        Task Update(CandidateProfile item);
        Task Delete(string id);
    }
}
