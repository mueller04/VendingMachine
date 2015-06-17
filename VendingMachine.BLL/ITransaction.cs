using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.BLL
{
    interface ITransaction
    {
        void AddToDisplayTotal(decimal price);
        void SubtractFromDisplayTotal(decimal price);
        void AddToReturnTotal(decimal price);
        void SubtractFromReturnTotal(decimal price);
        string ProductVended(Product product);
        void ProcessChange(Product product);
        void ProcessInventory(Product product);
    }
}
