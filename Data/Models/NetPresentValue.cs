namespace Data.Models
{
    public class NetPresentValue : SqlEntity
    {
        public double CashInflow { get; set; }

        public double CashOutflow { get; set; }

        public double LowerBoundDiscountRate { get; set; }

        public double UpperBoundDiscountRate { get; set; }

        public double DiscountRateIncrement { get; set; }

        public int TimePeriod { get; set; }
    }
}