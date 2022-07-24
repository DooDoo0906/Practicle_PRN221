using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateDAO candidateDAO;
        public CandidateRepository(CandidateDAO candidateDAO)
        {
            this.candidateDAO = candidateDAO;
        }
        public async Task Delete(string id) => await candidateDAO.Delete(id);

        public async Task<CandidateProfile> GetCandidateById(string id)=> await candidateDAO.GetCandidateByID(id);

        public  IQueryable<CandidateProfile> GetCandidates()=>  candidateDAO.GetCandidates();

        public async Task Insert(CandidateProfile item)=> await candidateDAO.Insert(item);


        public async Task Update(CandidateProfile item) => await candidateDAO.Update(item);
    }
}
