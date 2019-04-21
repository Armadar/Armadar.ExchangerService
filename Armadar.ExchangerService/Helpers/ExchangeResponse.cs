using Armadar.ExchangerService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armadar.ExchangerService.Helpers
{
    public class ExchangeResponse
    {
        public string from { get; set; }
        public string to { get; set; }
        public decimal rate { get; set; }
        public DateTime dateRate { get; set; }
        public decimal amount { get; set; }
        public decimal value { get; set; }
    }
    public class FormatterResponse
    {
        public static ExchangeResponse getInfoResponse(Exchange input,Exchange info)
        {
            ExchangeResponse r = new ExchangeResponse();

            string operation = info.operation;
            decimal rate = info.rate;
            decimal value = operation == "D" ? input.amount / rate : input.amount * rate;

            r.from = input.from;
            r.to = input.to;
            r.rate = info.rate;
            r.amount = input.amount;
            r.dateRate = info.dateRate;
            r.value = Convert.ToDecimal(value.ToString("N4"));

            return r;
        }
        public static ExchangeResponse getInfoResponse(string from, string to, decimal amount, Exchange info)
        {
            ExchangeResponse r = new ExchangeResponse();

            string operation = info.operation;
            decimal rate = info.rate;
            decimal value = operation == "D" ? amount / rate : amount * rate;

            r.from = from;
            r.to = to;
            r.rate = info.rate;
            r.amount = amount;
            r.dateRate = info.dateRate;
            r.value = Convert.ToDecimal(value.ToString("N4"));

            return r;
        }
    }
}
