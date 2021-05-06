using DispatchProxyExample.Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DispatchProxyExample.Business.Services
{
    public class CentralBankCurrencyService : ICurrencyService
    {
        public float GetCurrency(int fromCurrencyId, int toCurrencyId, DateTime time)
        {
            ///...
            return 8.4F;
        }
    }
}
