using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using accounts_api.Models;
using Microsoft.EntityFrameworkCore;

namespace accounts_api.Contexts
{
    public class AccountContext : DbContext
    {
        public AccountContext()
        {
        }

        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
