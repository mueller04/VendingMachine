using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.BLL;

namespace VendingMachine.DisplayTests
{
    [TestFixture]
    class ProductDisplayTests
    {
        [Test]
        [RequiresSTA]
        public void WhenBalanceIsHighEnoughVendProductUI()
        {
            
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.Transaction.DisplayTotal = 1.2M;
            window.ProductClick("cola");
            Assert.AreEqual(0, window.Transaction.DisplayTotal);
            Assert.AreEqual(.2M, window.Transaction.ReturnTotal);
            Assert.AreEqual(4, window.Transaction.Products[0].OnHand);
        }

        [Test]
        [RequiresSTA]
        public void WhenBalanceIsTooLowFailUpdateUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.Transaction.DisplayTotal = .9M;
            window.ProductClick("cola");
            Assert.AreEqual(.9M, window.Transaction.DisplayTotal);
            Assert.AreEqual(5, window.Transaction.Products[0].OnHand);
        }

        [Test]
        [RequiresSTA]
        public void WhenBalanceHighEnoughDisplayTHANKYOUUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.Transaction.DisplayTotal = 1.2M;
            window.ProductClick("cola");
            Assert.AreEqual("THANK YOU", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void ResetDisplayUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.txtDisplay.Text = "$2.00";
            window.ResetDisplay();
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void ResetDisplayWithBALANCEUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.Transaction.DisplayTotal = 1.2M;
            window.ProductClick("cola");
            window.ResetDisplay();
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenBalanceIsTooLowDisplayPRICEUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.Transaction.DisplayTotal = .9M;
            window.ProductClick("cola");
            Assert.AreEqual("PRICE $1.00", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenProductIsChosenChangeIsGivenUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.Transaction.DisplayTotal = 1.4M;
            window.ProductClick("cola");
            Assert.AreEqual("$0.40", window.txtCoinReturn.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenSoldOutProductIsChosenThenResetDisplayCurrentBalanceUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.Transaction.DisplayTotal = 1.5M;
            window.ProductClick("candy");
            window.ResetDisplay();
            Assert.AreEqual("$1.50", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenSoldOutProductIsChosenThenResetDisplayINSERTCOINUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.ProductClick("candy");
            window.ResetDisplay();
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
        }

    }
}
