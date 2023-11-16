
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Brand
    {
        [JsonIgnore]
        public int BrandID { get; set; }

        [MaxLengthCharacters(40)]
        public string Name { get; set; }= string.Empty;

        [MaxLengthCharacters(300)]
        public string Logo { get; set; }= string.Empty;
    }
}
