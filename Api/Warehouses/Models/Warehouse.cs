using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Warehouses.Models
{
    public class Warehouse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}
