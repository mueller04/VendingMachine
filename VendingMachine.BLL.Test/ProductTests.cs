using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.BLL.Test
{
    [TestFixture]
    class ProductTests
    {

        [Test]
        public void WhenProductSelectedAndBalanceHighEnoughVend()
        {
            Transaction transaction = new Transaction();
            transaction.DisplayTotal = .70M;
            Assert.AreEqual("THANK YOU", transaction.ProductVended(transaction.Products[1]));
            Assert.AreEqual(0, transaction.DisplayTotal);
            Assert.AreEqual(4, transaction.Products[1].OnHand);
            Assert.AreEqual(.20M, transaction.ReturnTotal);
        }

        [Test]
        public void WhenProductSelectedAndBalanceTooLow()
        {
            Transaction transaction = new Transaction();
            transaction.DisplayTotal = .40M;
            Assert.AreEqual("PRICE $0.50", transaction.ProductVended(transaction.Products[1]));
            Assert.AreEqual(.40M, transaction.DisplayTotal);
            Assert.AreEqual(5, transaction.Products[1].OnHand);
        }

        [Test]
        public void WhenProductSelectedMakeChange()
        {
            Transaction transaction = new Transaction();
            transaction.DisplayTotal = 1.60M;
            transaction.ProductVended(transaction.Products[0]);
            Assert.AreEqual(0, transaction.DisplayTotal);
            Assert.AreEqual(.60M, transaction.ReturnTotal);
        }

        [Test]
        public void WhenProductSelectedAndThereExistsNoInventoryVendFails()
        {
            Transaction transaction = new Transaction();
            transaction.DisplayTotal = 4.00M;
            Assert.AreEqual(4.00M, transaction.DisplayTotal);
            Assert.AreEqual(0, transaction.Products[2].OnHand);
        }

        [Test]
        public void WhenProductSelectedAndThereExistsNoInventoryDisplaySOLDOUT()
        {
            Transaction transaction = new Transaction();
            transaction.DisplayTotal = .1M;
            Assert.AreEqual("SOLD OUT", transaction.ProductVended(transaction.Products[2]));
        }

        

    }
}
