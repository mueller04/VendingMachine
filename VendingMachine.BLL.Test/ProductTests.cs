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
            Assert.AreEqual(true, transaction.ProductVended(transaction.Products[2]));
            Assert.AreEqual(.05M, transaction.DisplayTotal);
            Assert.AreEqual(4, transaction.Products[2].OnHand);
        }

        [Test]
        public void WhenProductSelectedAndBalanceTooLow()
        {
            Transaction transaction = new Transaction();
            transaction.DisplayTotal = .60M;
            Assert.AreEqual(false, transaction.ProductVended(transaction.Products[2]));
            Assert.AreEqual(.60M, transaction.DisplayTotal);
            Assert.AreEqual(5, transaction.Products[2].OnHand);
        }

    }
}
