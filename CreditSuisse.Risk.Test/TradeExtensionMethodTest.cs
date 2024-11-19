using CreditSuisse.Risk.Domain.Entities;
using CreditSuisse.Risk.Domain.Enums;
using CreditSuisse.Risk.Domain.ExtensionMethods;
using System.Globalization;

namespace CreditSuisse.Risk.Test
{
    public class TradeExtensionMethodTest
    {
        [Fact(DisplayName ="Categorizar_EXPIRED")]
        public void Categorizar_EXPIRED()
        {
            var trade = new Trade(400000, "Public", DateTime.ParseExact("07/01/2020", "MM/dd/yyyy", new CultureInfo("pt-BR")));

            var category= trade.Categorize(DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", new CultureInfo("pt-BR")));

            Assert.Equal(TradeCategoryEnum.EXPIRED.ToString(), category);
        }

        [Fact(DisplayName = "Categorizar_HIGHRISK")]
        public void Categorizar_HIGHRISK()
        {
            var trade = new Trade(2000000, "Private", DateTime.ParseExact("12/29/2025", "MM/dd/yyyy", new CultureInfo("pt-BR")));

            var category = trade.Categorize(DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", new CultureInfo("pt-BR")));

            Assert.Equal(TradeCategoryEnum.HIGHRISK.ToString(), category);
        }

        [Fact(DisplayName = "Categorizar_MEDIUMRISK")]
        public void Categorizar_MEDIUMRISK()
        {
            var trade = new Trade(5000000, "Public", DateTime.ParseExact("01/02/2024", "MM/dd/yyyy", new CultureInfo("pt-BR")));

            var category = trade.Categorize(DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", new CultureInfo("pt-BR")));

            Assert.Equal(TradeCategoryEnum.MEDIUMRISK.ToString(), category);
        }

        [Fact(DisplayName = "Categorizar_NOCATEGORY")]
        public void Categorizar_NOCATEGORY()
        {
            var trade = new Trade(1, "Private", DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", new CultureInfo("pt-BR")));

            var category = trade.Categorize(DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", new CultureInfo("pt-BR")));

            Assert.Equal(TradeCategoryEnum.NOCATEGORY.ToString(), category);
        }
    }
}