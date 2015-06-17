using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.BLL
{
    public class Transaction : ITransaction
    {
        public decimal DisplayTotal { get; set; }
        public decimal ReturnTotal { get; set; }
        public bool ExactChangeEnabled { get; set; }

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
                OnHand = 0
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

        public string ProductVended(Product product)
        {
            if (product.OnHand <= 0)
            {
                return "SOLD OUT";
            }
            else if (product.Price > DisplayTotal)
            {
                return ("PRICE " + product.Price.ToString("C"));
            }
            else if (ExactChangeEnabled && product.Price != DisplayTotal)
            {
                return "EXACT CHANGE ONLY";
            }
            else
            {         
                ProcessChange(product);
                ProcessInventory(product);
                return "THANK YOU";
            }
        }

        public void ProcessChange(Product product)
        {
            DisplayTotal -= product.Price;
            ReturnTotal += DisplayTotal;
            DisplayTotal = 0;
            
        }

        public void ProcessInventory(Product product)
        {
            product.OnHand--;
        }
        
    }
}