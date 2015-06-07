using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.DisplayTests
{
    [TestFixture]
    class ProductDisplayTests
    {
        [Test]
        [RequiresSTA]
        public void WhenBalanceIsHighEnoughVendProductUI()
        {
            MainWindow window = new MainWindow();
            window.transaction.DisplayTotal = 1.2M;
            window.ProductClick("cola");
            Assert.AreEqual(.2M, window.transaction.DisplayTotal);
            Assert.AreEqual(4, window.transaction.Products[0].OnHand);
        }

        [Test]
        [RequiresSTA]
        public void WhenBalanceIsTooLowFailUpdateUI()
        {
            MainWindow window = new MainWindow();
            window.transaction.DisplayTotal = .9M;
            window.ProductClick("cola");
            Assert.AreEqual(.9M, window.transaction.DisplayTotal);
            Assert.AreEqual(5, window.transaction.Products[0].OnHand);
        }



    }
}
