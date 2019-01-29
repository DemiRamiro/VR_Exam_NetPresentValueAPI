namespace NetPresentValueAPI.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class NetPresentValueView
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cashFlows")]
        public IEnumerable<CashFlowView> CashFlows { get; set; }

        [JsonProperty("lowerBoundDiscountRate")]
        public double LowerBoundDiscountRate { get; set; }

        [JsonProperty("upperBoundDiscountRate")]
        public double UpperBoundDiscountRate { get; set; }

        [JsonProperty("discountRateIncrement")]
        public double DiscountRateIncrement { get; set; }
    }
}