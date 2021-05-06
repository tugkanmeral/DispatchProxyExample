using DispatchProxyExample.Business.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DispatchProxyExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public TestController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public string Get()
        {
            _paymentService.Pay();

            return "Dooone!";
        }
    }
}
