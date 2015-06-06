using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendingMachine.BLL
{

    public static class Coin
    {

        public static string DetermineCoin(CoinSizeEnum size, CoinWeightEnum weight)
        {
            if (size == CoinSizeEnum.micrometer21210 && weight == CoinWeightEnum.grams5000) return "Nickel";
            return "Invalid Coin";            
        }

    }
}
