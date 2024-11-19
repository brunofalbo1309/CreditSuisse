using CreditSuisse.Risk.Domain.Entities;
using CreditSuisse.Risk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.Risk.Domain.ExtensionMethods
{
    public static class TradeExtensionMethods
    {

        static double limiteValue = 1000000;

        public static string Categorize(this Trade trade, DateTime referenceDate) 
        {
            //EXPIRED
            if (trade.NextPaymentDate.AddDays(30) < referenceDate)
                return TradeCategoryEnum.EXPIRED.ToString();

            //HIGHRISK
            if(trade.Value >= limiteValue && trade.ClientSector.ToLower().Equals("private"))
                return TradeCategoryEnum.HIGHRISK.ToString();

            //MEDIUMRISK
            if (trade.Value >= limiteValue && trade.ClientSector.ToLower().Equals("public"))
                return TradeCategoryEnum.MEDIUMRISK.ToString();

            return TradeCategoryEnum.NOCATEGORY.ToString();
        }
    }
}
