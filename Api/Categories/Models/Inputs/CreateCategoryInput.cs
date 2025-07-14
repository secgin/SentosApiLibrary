using System.Text.Json.Serialization;

namespace SentosApiLibrary.Api.Categories.Models.Inputs
{
    public class CreateCategoryInput
    {
        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("parent_id")]
        public int ParentId { get;}

        public CreateCategoryInput(string name, int parentId = 0)
        { 
            Name = name;
            ParentId = parentId;
        }
    }
}
