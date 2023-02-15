namespace CurrencyExchange.Models;

public enum Currency
{
    PLN = 0, THB = 1, USD = 2, AUD = 3, HKD = 4, CAD = 5, NZD = 6, SGD = 7, EUR = 8, HUF = 9, CHF = 10, 
    GBP = 11, UAH = 12, JPY = 13, CZK = 14, DKK = 15, ISK = 16, NOK = 17, SEK = 18, RON = 19, BGN = 20, 
    TRY = 21, ILS = 22, CLP = 23, PHP = 24, MXN = 25, ZAR = 26, BRL = 27, MYR = 28, IDR = 29, INR = 30, 
    KRW = 31, CNY = 32, XDR = 33,
}

public class Exchange
{
    public Decimal Amount { get; set; }
    public Currency FromCurrency { get; set; }
    public Currency ToCurrency { get; set; }
}

