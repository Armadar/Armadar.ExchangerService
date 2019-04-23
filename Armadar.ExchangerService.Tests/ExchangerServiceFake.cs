using System;
using System.Collections.Generic;
using System.Text;
using Armadar.ExchangerService.Entities;

namespace Armadar.ExchangerService.Tests
{
    public class ExchangerServiceFake
    {
        private readonly List<Exchange> _exchanges;
        public ExchangerServiceFake()
        {
            _exchanges = new List<Exchange>() {
                new Exchange(){  from="PEN",to="USD", rate= Convert.ToDecimal("3.3"), operation ="M", dateRate=DateTime.Now,isActive=true },
                new Exchange(){  from="USD",to="PEN", rate= Convert.ToDecimal("3.25"), operation ="D", dateRate=DateTime.Now,isActive=true },
                new Exchange(){  from="PEN",to="EUR", rate= Convert.ToDecimal("3.8"), operation ="M", dateRate=DateTime.Now,isActive=false }
            };
        }

        public Exchange GetExchange(string from, string to)
        {
            return _exchanges.Find(exc => exc.from == from && exc.to == to);
        }
    }
}