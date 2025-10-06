using System.Text.Json.Serialization;

namespace SentosApiLibrary
{
    public class PaginationResponse<T>
    {
        [JsonPropertyName("data")]
        public IEnumerable<T> Data { get; set; } = [];

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("total_elements")]
        public int TotalElements { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
    }
}
