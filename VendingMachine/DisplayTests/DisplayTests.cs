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
        public void WhenNoInputForInsertCoinGetMessage()
        {
            MainWindow window = new MainWindow();
            window.InsertCoinClick();
            //Assert.AreEqual("Select a coin then press Insert Coin", window.coin);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsNickelForInsertCoinAddToDisplay()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Nickel";
            window.InsertCoinClick();
            Assert.AreEqual("$0.05", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsDimeForInsertCoinAddToDisplay()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Dime";
            window.InsertCoinClick();
            Assert.AreEqual("$0.10", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsQuarterForInsertCoinAddToDisplay()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Quarter";
            window.InsertCoinClick();
            Assert.AreEqual("$0.25", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsPennyForInsertCoinDoNotIncreaseBalance()
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
        public void WhenNoSelectionIsMadeDisplayINSERTCOIN()
        {
            MainWindow window = new MainWindow();
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsPennyDisplayINSERTCOIN()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            Assert.AreEqual("INSERT COIN", window.txtDisplay.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsPennyReturnCoin()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            Assert.AreEqual("1 Coins", window.txtCoinReturn.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsTwoPenniesReturnCoin()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            window.InsertCoinClick();
            Assert.AreEqual("2 Coins", window.txtCoinReturn.Text);
        }        
        
        
        [Test]
        [RequiresSTA]
        public void WhenPickupChangeisClickedClearBox()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            window.PickupChangeClick();
            Assert.AreEqual("Coin Return Slot", window.txtCoinReturn.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenPickupChangeisClickedClearList()
        {
            MainWindow window = new MainWindow();
            window.lstInsertCoin.SelectedItem = "Penny";
            window.InsertCoinClick();
            window.PickupChangeClick();
            Assert.AreEqual(0, window.transaction.ReturnTotal.Count());
        }
        
    }
}
