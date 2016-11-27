using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace accounts_api.Models
{
    public enum AccountStatus
    {
        Created = 1,
        Active = 2,
        Suspended = 3,
        Closed = 4
    }
}
