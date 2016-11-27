using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace accounts_api.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Name {get; set;}
        
        public AccountStatus Status {get; set;}
        
        public DateTime CreationDate { get; set; }

        public List<Contact> Contacts {get; set;}
        
        public Account()
        {
            Contacts = new List<Contact>();
        }
    }
}
