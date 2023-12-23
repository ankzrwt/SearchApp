using Newtonsoft.Json;

namespace SerachApp.Models
{
    public class FilterModel
    {

        [JsonProperty("ProductName")]
        public string? ProductName { get; set; }
        [JsonProperty("Size")]
        public string? Size { get; set; }
        [JsonProperty("Price")]
        public int? Price { get; set; }
        [JsonProperty("MfgDate")]
        public DateTime? MfgDate { get; set; }
        [JsonProperty("Category")]
        public string? Category { get; set; }
        [JsonProperty("Conjunction")]
        public string? Conjunction { get; set; }
    }
}
