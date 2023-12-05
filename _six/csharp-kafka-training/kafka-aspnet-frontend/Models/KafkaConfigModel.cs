namespace kafka_aspnet_frontend.Models
{
  public class KafkaConfigModel
  {
    public string? BootstrapServers { get; set; }
    public string? SaslUsername { get; set; }
    public string? SaslPassword { get; set; }
    public string? SslCaLocation { get; set; }
  }
}