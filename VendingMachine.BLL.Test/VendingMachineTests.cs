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
            Assert.AreEqual(.05M, Coin.DetermineCoin(CoinSizeEnum.micrometer21210, CoinWeightEnum.milligram5000));
        }

        [Test]
        public void WhenDimeIsInsertedDetermineDime()
        {
            Assert.AreEqual(.10M, Coin.DetermineCoin(CoinSizeEnum.mirometer17910, CoinWeightEnum.milligram2268));
        }

        [Test]
        public void WhenQuarterIsInsertedDetermineQuarter()
        {
            Assert.AreEqual(.25M, Coin.DetermineCoin(CoinSizeEnum.micrometer24260, CoinWeightEnum.milligram5670));
        }

        [Test]
        public void WhenPennyIsInsertedDetermineInvalid()
        {
            try 
	        {	        
		        decimal value = Coin.DetermineCoin(CoinSizeEnum.micrometer19050, CoinWeightEnum.milligram2500); 
	        }
	        catch (Exception e)
	        {
                Assert.AreEqual("Not a valid coin", e.Message);
	        }
        }
    }
}
