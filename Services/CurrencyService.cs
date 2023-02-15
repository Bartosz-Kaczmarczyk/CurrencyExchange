using CurrencyExchange.Models;
using Newtonsoft.Json;

namespace CurrencyExchange.Services;

public interface ICurrencyService
{
    decimal CurrencyExchange(Exchange currencyExchange);
    Task<List<CurrencyResponse>> GetExchangeRates();
}

public class CurrencyService : ICurrencyService
{
    /// <inheritdoc/>

    private decimal GetRate(Currency code)
    {
        var response = GetExchangeRates().Result;
        IEnumerable<Rate> rates = response[0].rates;
        decimal rate;

        if (code == Currency.PLN)
        {
            rate = 1m;
        }
        else
        {
            try
            {
                rate = rates.First(r => r.code.Equals(code)).mid;
            } catch (Exception e)
            {
                throw new Exception("Currency code not found");
            }               
        }

        if (rate > 0)
        {
            return rate;
        }

        throw new Exception("Rate value is oncorrect");
        
    }

    public async Task<List<CurrencyResponse>> GetExchangeRates()
    {
        using (var httpClient = new HttpClient())
        {
            var result = await httpClient.GetAsync("http://api.nbp.pl/api/exchangerates/tables/A/");
            var json = await result.Content.ReadAsStringAsync();
            var currency = JsonConvert.DeserializeObject<List<CurrencyResponse>>(json);
            if (currency != null)
            {
                return currency;
            }
            else
            {
                throw new Exception("Failed to fetch the data");
            }
        }
    }

    public decimal CurrencyExchange(Exchange currencyExchange)
    {
        decimal fromRate = GetRate(currencyExchange.FromCurrency);
        decimal toRate = GetRate(currencyExchange.ToCurrency);

        var value = Math.Round(currencyExchange.Amount * fromRate / toRate, 2);

        string output = $"{currencyExchange.Amount} {currencyExchange.FromCurrency} = {value} {currencyExchange.ToCurrency}";
        Console.WriteLine(output);

        return value;
    }
}

