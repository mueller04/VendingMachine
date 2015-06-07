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
            Assert.AreEqual(true, transaction.ProductVended(transaction.Products[2], transaction.DisplayTotal));
        }

        [Test]
        public void WhenProductSelectedAndBalanceTooLow()
        {
            Transaction transaction = new Transaction();
            transaction.DisplayTotal = .60M;
            Assert.AreEqual(false, transaction.ProductVended(transaction.Products[2], transaction.DisplayTotal));
        }


    }
}
