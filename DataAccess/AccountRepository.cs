using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDAO accountDAO;
        public AccountRepository(AccountDAO accountDAO)
        {
            this.accountDAO = accountDAO;
        }
        public async Task<Hraccount> GetAccount(string email, string password) => await accountDAO.GetAccount(email, password);
    }
}
