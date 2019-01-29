namespace Data.Models
{
    using System.Collections.Generic;

    public class NetPresentValue : SqlEntity
    {
        public IEnumerable<double> Cashflow { get; set; }

        public double LowerBoundDiscountRate { get; set; }

        public double UpperBoundDiscountRate { get; set; }

        public double DiscountRateIncrement { get; set; }
    }
}