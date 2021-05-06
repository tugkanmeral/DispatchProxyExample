using DispatchProxyExample.Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DispatchProxyExample.Business.Services
{
    public class BPaymentService : IPaymentService
    {
        private readonly ICurrencyService _currencyService;
        public BPaymentService(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public string Pay()
        {
            //...
            var currentCurrency = _currencyService.GetCurrency(1, 2, DateTime.UtcNow);
            //...
            return "Dooone!";
        }
    }
}
