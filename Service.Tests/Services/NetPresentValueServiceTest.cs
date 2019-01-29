namespace Service.Tests.Services
{
    using Data.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Service.Services;
    using Service.Tests.Stubs;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class NetPresentValueServiceTest
    {
        private NetPresentValueService target;

        [TestInitialize]
        public void Setup()
        {
            var stub = new ContextServiceStub();
            this.target = new NetPresentValueService(stub);
        }

        [TestMethod]
        public void Calculate_CashFlowIs150000AndDiscountRateIsFrom1Point2To1Point4Percent_ReturnsNegative76182Point26()
        {
            var expected = -76182.26;
            var npv = new NetPresentValue
            {
                CashFlows = new List<CashFlow>
                {
                    new CashFlow{ CashFlowValue = 150000 },
                    new CashFlow{ CashFlowValue = 50000 },
                    new CashFlow{ CashFlowValue = 25000 }
                },
                DiscountRateIncrement = .1,
                LowerBoundDiscountRate = 1.2,
                UpperBoundDiscountRate = 1.4
            };

            var netPresentValues = this.target.Calculate(npv);

            Assert.AreEqual(expected, netPresentValues.First().NetPresentValue);
        }

        [TestMethod]
        public void CalculateNetPresentValue_CashInflow1000AndCashOutflowIs500DiscountRateIs8AndTimePeriodIs3_Returns288Point55()
        {
            var cashFlow = new List<double>
            {
                1000,
                500,
                500,
                500
            };
            var discountRate = .08;
            var expected = 288.55;

            var actual = this.target.CalculateNetPresentValue(cashFlow, discountRate);

            Assert.AreEqual(expected, actual);
        }
    }
}