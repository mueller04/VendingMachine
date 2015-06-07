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
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Nickel";
            window.InsertCoinClick();
            Assert.AreEqual("$0.05", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsDimeForInsertCoinAddToDisplayUI()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Dime";
            window.InsertCoinClick();
            Assert.AreEqual("$0.10", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsQuarterForInsertCoinAddToDisplayUI()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Quarter";
            window.InsertCoinClick();
            Assert.AreEqual("$0.25", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsPennyForInsertCoinDoNotIncreaseBalanceUI()
        {
            MainWindow window = new MainWindow();

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
            MainWindow window = new MainWindow();
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsPennyDisplayINSERTCOINUI()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsPennyReturnCoinUI()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            Assert.AreEqual("$0.01", window.txtCoinReturn.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsTwoPenniesReturnCoinUI()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            window.InsertCoinClick();
            Assert.AreEqual("$0.02", window.txtCoinReturn.Text);
        }        
        
        
        [Test]
        [RequiresSTA]
        public void WhenPickupChangeisClickedClearBoxUI()
        {
            MainWindow window = new MainWindow();
            window.txtCoinReturn.Text = "$0.50";
            window.PickupChangeClick();
            Assert.AreEqual("Coin Return Slot", window.txtCoinReturn.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenPickupChangeisClickedClearListUI()
        {
            MainWindow window = new MainWindow();
            window.transaction.ReturnTotal = .50M;
            window.PickupChangeClick();
            Assert.AreEqual(0, window.transaction.ReturnTotal);
        }

        [Test]
        [RequiresSTA]
        public void WhenPickupChangeisClickedClearListandBoxUI()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            window.PickupChangeClick();
            Assert.AreEqual(0, window.transaction.ReturnTotal);
            Assert.AreEqual("Coin Return Slot", window.txtCoinReturn.Text);
        }

        
    }
}
