using CreditSuisse.Risk.Domain.Entities;
using CreditSuisse.Risk.Domain.Enums;
using CreditSuisse.Risk.Domain.ExtensionMethods;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace CreditSuisse.Risk.Test
{
    public class PortfolioExtensionMethodsTest
    {
        [Fact(DisplayName = "Validar_Portfolio")]
        public void Validar_Portfolio()
        {
            var trades = new List<Trade>()
            {
                new Trade(400000, "Public", DateTime.ParseExact("07/01/2020", "MM/dd/yyyy", new CultureInfo("pt-BR"))),
                new Trade(2000000, "Private", DateTime.ParseExact("12/29/2025", "MM/dd/yyyy", new CultureInfo("pt-BR"))),
                new Trade(5000000, "Public", DateTime.ParseExact("01/02/2024", "MM/dd/yyyy", new CultureInfo("pt-BR"))),
                new Trade(1, "Private", DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", new CultureInfo("pt-BR")))
            };

            var portfolio = new Portfolio(DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", new CultureInfo("pt-BR")), 4, trades);

            var expected = new List<string>() { "EXPIRED", "HIGHRISK", "MEDIUMRISK", "NOCATEGORY" };


            var categories = portfolio.CategorizeTrades();


            Assert.Equal(expected, categories);
        }
    }
}
