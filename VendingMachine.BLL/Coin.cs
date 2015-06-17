using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendingMachine.BLL
{

    public static class Coin
    {

        public static decimal DetermineCoin(CoinSizeEnum size, CoinWeightEnum weight)
        {
            if (size == CoinSizeEnum.micrometer21210 && weight == CoinWeightEnum.milligram5000) return .05M;
            if (size == CoinSizeEnum.mirometer17910 && weight == CoinWeightEnum.milligram2268) return .10M;
            if (size == CoinSizeEnum.micrometer24260 && weight == CoinWeightEnum.milligram5670) return .25M;
            throw new ArgumentException("Not a valid coin");  
        }

    }
}
