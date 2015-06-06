using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine;


namespace VendingMachine.BLL.Test
{

   

    [TestFixture]
    public class VendingMachineTests
    {

        [Test]
        public void WhenNickelIsInsertedDeteremineNickel()
        {
            Assert.AreEqual("Nickel", Coin.DetermineCoin(CoinSizeEnum.micrometer21210, CoinWeightEnum.milligram5000));
        }

        [Test]
        public void WhenDimeIsInsertedDetermineDime()
        {
            Assert.AreEqual("Dime", Coin.DetermineCoin(CoinSizeEnum.mirometer17910, CoinWeightEnum.milligram2268));
        }

        [Test]
        public void WhenQuarterIsInsertedDetermineQuarter()
        {
            Assert.AreEqual("Quarter", Coin.DetermineCoin(CoinSizeEnum.micrometer24260, CoinWeightEnum.milligram5670));
        }

    }
}
