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
            var lowerBoundDiscountRate = npv.LowerBoundDiscountRate / 100;
            var upperBoundDiscountRate = npv.UpperBoundDiscountRate / 100;
            var discountRateIncrement = npv.DiscountRateIncrement / 100;
            var discountRateRange = this.CalculateDiscountRateRange(lowerBoundDiscountRate, upperBoundDiscountRate, discountRateIncrement);
            foreach (var rate in discountRateRange)
            {
                var netPresentValue = this.CalculateNetPresentValue(npv.Cashflow, rate);
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