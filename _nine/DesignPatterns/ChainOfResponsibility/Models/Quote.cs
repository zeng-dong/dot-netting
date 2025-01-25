namespace ChainOfResponsibility.Models;

public class Quote
{
    public int Id { get; set; }
    public string Program { get; set; }
    public string Product { get; set; }
    public DateTime EffectiveDate { get; set; }
}