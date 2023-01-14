using System.Text.Json.Serialization;

namespace DistributedTests;

public class Policy
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Premium { get; set; }
    public Liability? Liability { get; set; }
}

[JsonSerializable(typeof(Policy))]
public partial class CacheSourceGenerationContext : JsonSerializerContext
{
}

public class Liability
{
    public int Id { get; set; }
    public decimal Limit { get; set; }
    public decimal Deductible { get; set; }
}