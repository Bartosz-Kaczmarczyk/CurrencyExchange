namespace CurrencyExchange.Models;

public class CurrencyResponse
{
    public string table { get; set; }
    public string no { get; set; }
    public string effectiveDate { get; set; }
    public IEnumerable<Rate> rates { get; set; }
}