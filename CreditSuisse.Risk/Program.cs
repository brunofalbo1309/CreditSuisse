using CreditSuisse.Risk.Domain.Entities;
using CreditSuisse.Risk.Domain.ExtensionMethods;
using System.Globalization;

namespace CreditSuisse.Risk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Credit Suisse - Risk!");
            
            Console.WriteLine("Insert reference date:");
            var referenceDate = DateTime.ParseExact(Console.ReadLine(),"MM/dd/yyyy",new CultureInfo("pt-BR"));

            Console.WriteLine("Insert Number of trades:");
            var numberOfTrades = int.Parse(Console.ReadLine());


            var trades = new List<Trade>();
            for (int tradeCounter = 0; tradeCounter < numberOfTrades; tradeCounter++)
            {
                Console.WriteLine($"Insert #{tradeCounter+1} trade informations:");
                var tradeInformations = Console.ReadLine().Split(' ');

                var tradeValue = double.Parse(tradeInformations[0]);
                var clientSector = tradeInformations[1];
                var nextPaymentDate = DateTime.ParseExact(tradeInformations[2], "MM/dd/yyyy", new CultureInfo("pt-BR"));

                trades.Add(new Trade(tradeValue, clientSector, nextPaymentDate));
            }

            var portfolio = new Portfolio(referenceDate, numberOfTrades,trades);
            var tradesCategories = portfolio.CategorizeTrades();

            Console.WriteLine();
            Console.WriteLine("###############################################");
            Console.WriteLine();
            Console.WriteLine("OUTPUT");

            foreach (var category in tradesCategories)
            {
                Console.WriteLine(category);
            }
            
            Console.Read();

        }
    }
}
