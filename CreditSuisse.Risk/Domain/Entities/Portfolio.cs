using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.Risk.Domain.Entities
{
    public class Portfolio
    {
        public Portfolio(DateTime referenceDate, int numberOfTrades, List<Trade> trades)
        {
            ReferenceDate = referenceDate;
            NumberOfTrades = numberOfTrades;
            Trades = trades;
        }

        public DateTime ReferenceDate { get; private set; }
        public int NumberOfTrades { get; private set; }
        public List<Trade> Trades { get; private set; }
    }
}
