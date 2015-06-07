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
            Assert.AreEqual(0, window.transaction.DisplayTotal);
            Assert.AreEqual(.2M, window.transaction.ReturnTotal);
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

        [Test]
        [RequiresSTA]
        public void WhenBalanceHighEnoughDisplayTHANKYOUUI()
        {
            MainWindow window = new MainWindow();
            window.transaction.DisplayTotal = 1.2M;
            window.ProductClick("cola");
            Assert.AreEqual("THANK YOU", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void ResetDisplayUI()
        {
            MainWindow window = new MainWindow();
            window.txtDisplay.Text = "$2.00";
            window.ResetDisplay();
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void ResetDisplayWithBALANCEUI()
        {
            MainWindow window = new MainWindow();
            window.transaction.DisplayTotal = 1.2M;
            window.ProductClick("cola");
            window.ResetDisplay();
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenBalanceIsTooLowDisplayPRICEUI()
        {
            MainWindow window = new MainWindow();
            window.transaction.DisplayTotal = .9M;
            window.ProductClick("cola");
            Assert.AreEqual("PRICE $1.00", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenProductIsChosenChangeIsGivenUI()
        {
            MainWindow window = new MainWindow();
            window.transaction.DisplayTotal = 1.4M;
            window.ProductClick("cola");
            Assert.AreEqual("$0.40", window.txtCoinReturn.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenSoldOutProductIsChosenThenResetDisplayCurrentBalanceUI()
        {
            MainWindow window = new MainWindow();
            window.transaction.DisplayTotal = 1.5M;
            window.ProductClick("candy");
            window.ResetDisplay();
            Assert.AreEqual("$1.50", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenSoldOutProductIsChosenThenResetDisplayINSERTCOINUI()
        {
            MainWindow window = new MainWindow();
            window.ProductClick("candy");
            window.ResetDisplay();
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
        }

    }
}
