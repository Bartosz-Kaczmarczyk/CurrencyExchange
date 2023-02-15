namespace CurrencyExchange.Models;

public class Rate
{
    public string currency { get; set; }
    public Currency code { get; set; }
    public decimal mid { get; set; }

}