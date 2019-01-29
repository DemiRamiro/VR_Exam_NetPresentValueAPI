namespace Service.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Service.Models;

    public interface INetPresentValueService
    {
        double CalculateNetPresentValue(IEnumerable<double> cashflow, double rate);

        IEnumerable<NetPresentValueResult> Calculate(NetPresentValue npv);

        Task InsertNPVAsync(NetPresentValue netPresentValue);

        IEnumerable<NetPresentValue> GetNetPresentValues();

        void DeleteNPV(int id);
    }
}