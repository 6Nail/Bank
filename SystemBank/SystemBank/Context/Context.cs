using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemBank.DataAccess;

namespace SystemBank.Context
{
    public class Context: DbContext
    {      
        public DbSet<Account> Accounts { get; set;}
        public DbSet<Operation> Operations { get; set;}

    }
}
