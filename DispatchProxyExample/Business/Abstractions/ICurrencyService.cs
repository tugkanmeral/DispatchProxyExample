using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DispatchProxyExample.Business.Abstractions
{
    public interface ICurrencyService
    {
        float GetCurrency(int fromCurrencyId, int toCurrencyId, DateTime time);
    }
}
