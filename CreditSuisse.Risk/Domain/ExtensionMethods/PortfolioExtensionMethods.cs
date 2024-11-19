using CreditSuisse.Risk.Domain.Entities;
using CreditSuisse.Risk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.Risk.Domain.ExtensionMethods
{
    public static class PortfolioExtensionMethods
    {
        public static List<string> CategorizeTrades(this Portfolio portfolio)
        {
            var categories = new List<string>();

            if (portfolio.Trades.Count > 0)
            {
                foreach (var trade in portfolio.Trades)
                {
                    categories.Add(trade.Categorize(portfolio.ReferenceDate));
                }
            }
            else {
                categories.Add("No trades on portfolio");
            }

            return categories;
        }
    }
}
