using CurrencyExchange.Models;
using CurrencyExchange.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CurrencyExchange.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyService _currencyService;
    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }
    
    
    [SwaggerOperation(
        Summary = "Returns TO AMOUNT rounded to two significant digits",
        Description = @"Currency codes: <br />
                        PLN = 0, THB = 1, USD = 2, AUD = 3, HKD = 4, CAD = 5, NZD = 6, SGD = 7, EUR = 8, 
                        HUF = 9, CHF = 10, GBP = 11, UAH = 12, JPY = 13, CZK = 14, DKK = 15, ISK = 16, 
                        NOK = 17, SEK = 18, RON = 19, BGN = 20, TRY = 21, ILS = 22, CLP = 23, PHP = 24, 
                        MXN = 25, ZAR = 26, BRL = 27, MYR = 28, IDR = 29, INR = 30, KRW = 31, CNY = 32, XDR = 33,"
        )]
    [HttpGet("exchange")]
    public decimal CurrencyExchange([FromQuery] Exchange currencyExchange)
    {
        return _currencyService.CurrencyExchange(currencyExchange);
    }

    [SwaggerOperation(Summary = "Returns mid rates for all currencies from NBP")]
    [HttpGet]
    public IEnumerable<CurrencyResponse> GetExchangeRates()
    {
        return _currencyService.GetExchangeRates().Result;
    }
}
