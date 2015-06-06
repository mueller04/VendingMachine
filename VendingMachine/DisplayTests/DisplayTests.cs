using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            window.InsertCoinBox.SelectedItem = "Nickel";
            window.InsertCoinClick();
            Assert.AreEqual("$0.05", window.DisplayTextBox.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsDimeForInsertCoinAddToDisplay()
        {
            MainWindow window = new MainWindow();
            window.InsertCoinBox.SelectedItem = "Dime";
            window.InsertCoinClick();
            Assert.AreEqual("$0.10", window.DisplayTextBox.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsQuarterForInsertCoinAddToDisplay()
        {
            MainWindow window = new MainWindow();
            window.InsertCoinBox.SelectedItem = "Quarter";
            window.InsertCoinClick();
            Assert.AreEqual("$0.25", window.DisplayTextBox.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsPennyForInsertCoinDoNotIncreaseBalance()
        {
            MainWindow window = new MainWindow();
            window.InsertCoinBox.SelectedItem = "Penny";
            window.InsertCoinClick();
            Assert.AreEqual("$0.00", window.DisplayTextBox.Text);
        }

        [Test]
        [RequiresSTA]
        public void WhenNoSelectionIsMadeDisplayINSERTCOIN()
        {
            MainWindow window = new MainWindow();
            Assert.AreEqual("INSERT COIN", window.DisplayTextBox.Text);
        }

        

    }
}
