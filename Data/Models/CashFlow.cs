namespace Data.Models
{
    public class CashFlow : SqlEntity
    {
        public double CashFlowValue { get; set; }

        public NetPresentValue NetPresentValue { get; set; }
    }
}