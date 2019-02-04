namespace Service.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Interfaces;
    using Data.Models;
    using Service.Models;

    public class NetPresentValueService : INetPresentValueService
    {
        private readonly IContext<NetPresentValue> context;

        public NetPresentValueService(IContext<NetPresentValue> context)
        {
            this.context = context;
        }

        public IEnumerable<NetPresentValueResult> Calculate(NetPresentValue npv)
        {
            var netPresentValues = new Dictionary<string, double>();
            var lowerBoundDiscountRate = double.Parse((npv.LowerBoundDiscountRate / 100).ToString("0.####"));
            var upperBoundDiscountRate = double.Parse((npv.UpperBoundDiscountRate / 100).ToString("0.####"));
            var discountRateIncrement = double.Parse((npv.DiscountRateIncrement / 100).ToString("0.####"));
            foreach (var rate in this.CalculateDiscountRateRange(lowerBoundDiscountRate, upperBoundDiscountRate, discountRateIncrement))
            {
                var netPresentValue = this.CalculateNetPresentValue(npv.CashFlows.Select(c => c.CashFlowValue), rate);
                var percentage = rate.ToString("#0.##%");
                yield return new NetPresentValueResult
                {
                    DiscountRate = percentage,
                    NetPresentValue = netPresentValue,
                    Color = netPresentValue < 0 ? "#ff0000" : "#42A5F5"
                };
            }
        }

        public async Task InsertNPVAsync(NetPresentValue netPresentValue)
        {
            await this.context.InsertAsync(netPresentValue);
        }

        public IEnumerable<NetPresentValue> GetNetPresentValues()
        {
            return this.context.GetEntities();
        }

        public void DeleteNPV(int id)
        {
            var npv = new NetPresentValue { Id = id };
            this.context.Delete(npv);
        }

        public double CalculateNetPresentValue(IEnumerable<double> cashflow, double discountRate)
        {
            double presentValue = 0;
            foreach (var (cash, timePeriod) in cashflow.Select((c, i)=> (c, i)))
            {
                presentValue += double.Parse((timePeriod == 0 ? -cash : cash / Math.Pow(1 + discountRate, timePeriod)).ToString("0.##"));
            }

            return double.Parse(presentValue.ToString("0.##"));
        }

        private IEnumerable<double> CalculateDiscountRateRange(double lowerBoundDiscountRate, double upperBoundDiscountRate, double discountRateIncrement)
        {
            for (double discountRate = lowerBoundDiscountRate; discountRate <= upperBoundDiscountRate; discountRate += discountRateIncrement)
            {
                discountRate = double.Parse(discountRate.ToString("0.####"));
                yield return discountRate;
            }
        }
    }
}