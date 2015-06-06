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
            Assert.AreEqual("Nickel", Coin.DetermineCoin(CoinSizeEnum.micrometer21210, CoinWeightEnum.grams5000));
        }




    }
}
