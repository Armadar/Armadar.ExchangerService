using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Armadar.ExchangerService.Data;
using Armadar.ExchangerService.Entities;
using Armadar.ExchangerService.Helpers;

namespace Armadar.ExchangerService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExchangesController : ControllerBase
    {
        private readonly ExchangerContext _context;

        public ExchangesController(ExchangerContext context)
        {
            _context = context;
        }

        [HttpGet("getmoneypriceandvalue")]
        public IActionResult GetMoneyPriceAndValue([FromBody]Exchange exchangeInput)
        {
            if (!String.IsNullOrEmpty(exchangeInput.from) && !String.IsNullOrEmpty(exchangeInput.to))
            {
                if (exchangeInput.amount > 0)
                {
                    ExchangeResponse r = new ExchangeResponse();
                    var exchangeInfo = _context.Exchanges.SingleOrDefault(x => x.from == exchangeInput.from && x.to == exchangeInput.to && x.isActive);

                    if (exchangeInfo != null)
                    {
                        r = FormatterResponse.getInfoResponse(exchangeInput, exchangeInfo);
                    }
                    else
                    {
                        return BadRequest(new { message = "There is not info with those money codes" });
                    }
                    return Ok(r);
                }
                else
                {
                    return BadRequest(new { message = "please enter a valid amount" });
                }
            }
            else
            {
                return BadRequest(new { message = "the money codes are invalid" });
            }
        }
        // GET: api/Exchanges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exchange>>> GetExchanges()
        {
            return await _context.Exchanges.ToListAsync();
        }

        // GET: api/Exchanges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exchange>> GetExchange(long id)
        {
            var exchange = await _context.Exchanges.FindAsync(id);

            if (exchange == null)
            {
                return NotFound();
            }

            return exchange;
        }
        // GET: api/Exchanges/5
        [HttpGet("{from}/{to}/{amount}")]
        public ActionResult<Exchange> GetExchange(string from, string to, decimal amount)
        {
            if (!String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to))
            {
                if (amount > 0)
                {
                    ExchangeResponse r = new ExchangeResponse();
                    var exchangeInfo = _context.Exchanges.SingleOrDefault(x => x.from == from && x.to == to && x.isActive);

                    if (exchangeInfo != null)
                    {
                        r = FormatterResponse.getInfoResponse(from, to, amount, exchangeInfo);
                    }
                    else
                    {
                        return BadRequest(new { message = "There is not info with those money codes" });
                    }
                    return Ok(r);
                }
                else
                {
                    return BadRequest(new { message = "please enter a valid amount" });
                }
            }
            else
            {
                return BadRequest(new { message = "the money codes are invalid" });
            }
        }

        // PUT: api/Exchanges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExchange(long id, Exchange exchange)
        {
            if (id != exchange.Id)
            {
                return BadRequest();
            }

            _context.Entry(exchange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExchangeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Exchanges
        [HttpPost]
        public async Task<ActionResult<Exchange>> PostExchange(Exchange exchange)
        {
            _context.Exchanges.Add(exchange);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExchange", new { id = exchange.Id }, exchange);
        }

        // DELETE: api/Exchanges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Exchange>> DeleteExchange(long id)
        {
            var exchange = await _context.Exchanges.FindAsync(id);
            if (exchange == null)
            {
                return NotFound();
            }

            _context.Exchanges.Remove(exchange);
            await _context.SaveChangesAsync();

            return exchange;
        }

        private bool ExchangeExists(long id)
        {
            return _context.Exchanges.Any(e => e.Id == id);
        }
    }
}
