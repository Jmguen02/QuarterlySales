using Newtonsoft.Json;

namespace QuarterlySales.Models
{
    public class SalesGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Employee { get; set; } = DefaultFilter;
    }
}
