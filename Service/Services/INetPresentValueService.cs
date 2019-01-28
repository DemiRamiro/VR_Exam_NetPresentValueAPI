namespace Service.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Service.Models;

    public interface INetPresentValueService
    {
        IEnumerable<NetPresentValueResult> Calculate(NetPresentValue npv);

        Task InsertNPVAsync(NetPresentValue netPresentValue);

        IEnumerable<NetPresentValue> GetNetPresentValues();

        void DeleteNPV(int id);
    }
}