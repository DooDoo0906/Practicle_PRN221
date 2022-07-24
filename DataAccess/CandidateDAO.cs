using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public  class CandidateDAO
    {
        private readonly CandidateManagementContext context;
        public CandidateDAO(CandidateManagementContext context)
        {
            this.context = context;
        }

        public IQueryable<CandidateProfile> GetCandidates()
        {
            var items = from s in context.CandidateProfiles.Include(p => p.Posting)
                        select s;
            return items;
        }

        public async Task<CandidateProfile> GetCandidateByID(string id)
        {
            var item = await context.CandidateProfiles.AsNoTracking().FirstOrDefaultAsync(m => m.CandidateId == id);
            return item;
        }

        public async Task Insert(CandidateProfile citem)
        {
            var item = await GetCandidateByID(citem.CandidateId);
            if (item == null)
            {

                context.CandidateProfiles.Add(citem);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(CandidateProfile uitem)
        {
            var item = await GetCandidateByID(uitem.CandidateId);
            if (item != null)
            {
                context.CandidateProfiles.Update(uitem);
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(string id)
        {
            var item = await context.CandidateProfiles.FindAsync(id);

            if (item != null)
            {
                context.CandidateProfiles.Remove(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
