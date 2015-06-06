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
            Assert.AreEqual("Select a coin then press Insert Coin", window.coin);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsNickelForInsertCoinGetMessage()
        {
            MainWindow window = new MainWindow();
            window.InsertCoinBox.SelectedItem = "Nickel";
            window.InsertCoinClick();
            Assert.AreEqual("Nickel", window.coin);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsDimeForInsertCoinGetMessage()
        {
            MainWindow window = new MainWindow();
            window.InsertCoinBox.SelectedItem = "Dime";
            window.InsertCoinClick();
            Assert.AreEqual("Dime", window.coin);
        }

        [Test]
        [RequiresSTA]
        public void WhenInputIsQuarterForInsertCoinGetMessage()
        {
            MainWindow window = new MainWindow();
            window.InsertCoinBox.SelectedItem = "Quarter";
            window.InsertCoinClick();
            Assert.AreEqual("Quarter", window.coin);
        }

    }
}
