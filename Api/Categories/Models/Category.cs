using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Categories.Models
{
    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; }

        [JsonPropertyName("sub_categories")]
        public List<Category> SubCategories { get; set; } = [];
    }
}
