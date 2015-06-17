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
    class DisplayTests
    {
        
        [Test]
        [RequiresSTA]
        public void WhenInputIsNickelForInsertCoinAddToDisplayUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.lstInsertCoin.SelectedItem = "Nickel";
            window.InsertCoinClick();
            Assert.AreEqual("$0.05", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsDimeForInsertCoinAddToDisplayUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.lstInsertCoin.SelectedItem = "Dime";
            window.InsertCoinClick();
            Assert.AreEqual("$0.10", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsQuarterForInsertCoinAddToDisplayUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.lstInsertCoin.SelectedItem = "Quarter";
            window.InsertCoinClick();
            Assert.AreEqual("$0.25", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsPennyForInsertCoinDoNotIncreaseBalanceUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);

            window.lstInsertCoin.SelectedItem = "Dime";
            window.InsertCoinClick();
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();

            Assert.AreEqual("$0.10", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenNoSelectionIsMadeDisplayINSERTCOINUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsPennyDisplayINSERTCOINUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsPennyReturnCoinUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            Assert.AreEqual("$0.01", window.txtCoinReturn.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsTwoPenniesReturnCoinUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            window.InsertCoinClick();
            Assert.AreEqual("$0.02", window.txtCoinReturn.Text);
        }        
        
        
        [Test]
        [RequiresSTA]
        public void WhenPickupChangeisClickedClearBoxUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.txtCoinReturn.Text = "$0.50";
            window.PickupChangeClick();
            Assert.AreEqual("Coin Return Slot", window.txtCoinReturn.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenPickupChangeisClickedClearListUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.Transaction.ReturnTotal = .50M;
            window.PickupChangeClick();
            Assert.AreEqual(0, window.Transaction.ReturnTotal);
        }

        [Test]
        [RequiresSTA]
        public void WhenPickupChangeisClickedClearReturnTotalandBoxUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            window.PickupChangeClick();
            Assert.AreEqual(0, window.Transaction.ReturnTotal);
            Assert.AreEqual("Coin Return Slot", window.txtCoinReturn.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenPickupChangeisClickedClearDisplayTotalandDisplayBoxUI()
        {
            Transaction transaction = new Transaction();
            MainWindow window = new MainWindow(transaction);
            window.lstInsertCoin.SelectedItem = "Quarter";
            window.InsertCoinClick();
            window.PickupChangeClick();
            Assert.AreEqual(0, window.Transaction.ReturnTotal);
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
            Assert.AreEqual("Coin Return Slot", window.txtCoinReturn.Text);
        }

        
    }
}
