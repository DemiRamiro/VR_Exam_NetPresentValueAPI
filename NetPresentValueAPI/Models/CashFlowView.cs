namespace NetPresentValueAPI.Models
{
    using Newtonsoft.Json;

    public class CashFlowView
    {
        [JsonProperty("cashFlow")]
        public double CashFlowValue { get; set; }
    }
}