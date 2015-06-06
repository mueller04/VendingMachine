using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendingMachine.BLL.Test
{

   

    [TestFixture]
    public class VendingMachineTests
    {

        [Test]
        public void WhenNickelIsInsertedDeteremineNickel()
        {
            Coin coin = new Coin();
            Assert.AreEqual("Nickel", coin.DetermineCoin(CoinSizeEnum.micrometer21210, CoinWeightEnum.grams5000));
        
        }

    }
}
