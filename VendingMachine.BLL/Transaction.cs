using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.BLL
{
    public class Transaction
    {
        public decimal DisplayTotal { get; set; }
        public decimal ReturnTotal { get; set; }

        public List<Product> Products = new List<Product>()
        {
            new Product()
            {
                Name = "cola",
                Price = 1.00M,
                OnHand = 5
            },
            new Product()
            {
                Name = "chips",
                Price = .50M,
                OnHand = 5
            },
            new Product()
            {
                Name = "candy",
                Price = .65M,
                OnHand = 5
            }
        };

        public void AddToDisplayTotal(decimal price)
        {
            DisplayTotal += price;
        }

        public void SubtractFromDisplayTotal(decimal price)
        {
            DisplayTotal -= price;
        }

        public void AddToReturnTotal(decimal price)
        {
            ReturnTotal += price;
        }

        public void SubtractFromReturnTotal(decimal price)
        {
            ReturnTotal -= price;
        }

        public bool ProductVended(Product product)
        {
            if (product.Price < DisplayTotal)
            {
                DisplayTotal -= product.Price;
                product.OnHand--;
                return true;
            } else
            {
                return false;
            }


        }
        
    }
}