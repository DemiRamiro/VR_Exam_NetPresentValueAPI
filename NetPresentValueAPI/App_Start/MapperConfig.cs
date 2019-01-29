namespace NetPresentValueAPI.App_Start
{
    using AutoMapper;
    using Data.Models;
    using NetPresentValueAPI.Models;
    using Service.Models;

    public class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<NetPresentValueView, NetPresentValue>();
                cfg.CreateMap<CashFlowView, CashFlow>();
                cfg.CreateMap<NetPresentValue, NetPresentValueView>();
                cfg.CreateMap<CashFlow, CashFlowView>();
                cfg.CreateMap<NetPresentValueResult, NetPresentValueResultView>();
            });
        }
    }
}