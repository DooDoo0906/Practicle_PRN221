using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public  class AccountDAO
    {
        private readonly CandidateManagementContext context;
        public AccountDAO(CandidateManagementContext context)
        {
            this.context = context; 
        }

        public async Task<Hraccount> GetAccount(string email, string password)
        {
            return await context.Hraccounts.FirstOrDefaultAsync(m=> m.Email.Equals(email)&& m.Password.Equals(password));
        }
    }
}
