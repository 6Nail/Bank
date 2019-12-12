using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBank.DataAccess
{
    public class Operation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Account Account { get; set; }
        public string OperationType { get; set;}
        public int Cash { get; set; }
        public DateTime OperationDate { get; set; } = DateTime.Now;
    }
}
