namespace Service.Tests.Services
{
    using Data.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Service.Services;
    using Service.Tests.Stubs;

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
        public void Calculate_CashFlowIs100000AndDiscountRateIsFrom1To15PercentAndTimePeriodIs5Years_ReturnsNegative66478Point45()
        {
            var expected = -66478.45;
            var npv = new NetPresentValue
            {
                CashInflow = 100000,
                CashOutflow = 10000,
                DiscountRateIncrement = .0025,
                LowerBoundDiscountRate = 0.01,
                UpperBoundDiscountRate = 0.15,
                TimePeriod = 5
            };

            var netPresentValues = this.target.Calculate(npv);

            Assert.AreEqual(expected, netPresentValues["15%"]);
        }
    }
}