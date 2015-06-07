using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.BLL
{
    public class Transaction
    {
        public List<decimal> DisplayTotal { get; set; }
        public List<int> ReturnTotal { get; set; }

        public Transaction()
        {
            DisplayTotal = new List<decimal>();
            ReturnTotal = new List<int>();
        }
        
    }
}
