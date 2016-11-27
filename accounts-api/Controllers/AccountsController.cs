using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using accounts_api.Contexts;
using accounts_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace accounts_api.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        AccountContext _context;

        public AccountsController(AccountContext context){
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return _context.Accounts
                .Include(w => w.Contacts);
        }
    }
}
