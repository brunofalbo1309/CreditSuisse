using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.Risk.Aplication.Interfaces
{
    public interface IPortfolioService
    {
        List<string> Validate();
    }
}
