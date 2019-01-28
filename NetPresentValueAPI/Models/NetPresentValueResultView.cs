namespace NetPresentValueAPI.Models
{
    using Newtonsoft.Json;

    public class NetPresentValueResultView
    {
        [JsonProperty("netPresentValue")]
        public double NetPresentValue { get; set; }

        [JsonProperty("discountRate")]
        public string DiscountRate { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}