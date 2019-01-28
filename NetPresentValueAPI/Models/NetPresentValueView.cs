namespace NetPresentValueAPI.Models
{
    using Newtonsoft.Json;

    public class NetPresentValueView
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cashInflow")]
        public double CashInflow { get; set; }

        [JsonProperty("cashOutflow")]
        public double CashOutflow { get; set; }

        [JsonProperty("lowerBoundDiscountRate")]
        public double LowerBoundDiscountRate { get; set; }

        [JsonProperty("upperBoundDiscountRate")]
        public double UpperBoundDiscountRate { get; set; }

        [JsonProperty("discountRateIncrement")]
        public double DiscountRateIncrement { get; set; }

        [JsonProperty("timePeriod")]
        public int TimePeriod { get; set; }
    }
}