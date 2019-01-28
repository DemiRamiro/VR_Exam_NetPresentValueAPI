namespace NetPresentValueAPI.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using AutoMapper;
    using Data.Models;
    using NetPresentValueAPI.Models;
    using Service.Models;
    using Service.Services;

    public class NetPresentValueController : ApiController
    {
        private readonly INetPresentValueService netPresentValueService;

        public NetPresentValueController(INetPresentValueService netPresentValueService)
        {
            this.netPresentValueService = netPresentValueService;
        }

        [HttpPost]
        [Route("api/netpresentvalue/save")]
        public async Task<IHttpActionResult> CalculateAndSave([FromBody]NetPresentValueView netPresentValueView)
        {
            var npv = Mapper.Map<NetPresentValueView, NetPresentValue>(netPresentValueView);
            var netPresentValues = this.netPresentValueService.Calculate(npv);
            var result = Mapper.Map<IEnumerable<NetPresentValueResult>, IEnumerable<NetPresentValueResultView>>(netPresentValues);
            await this.netPresentValueService.InsertNPVAsync(npv);
            return this.Ok(result);
        }

        [HttpPost]
        [Route("api/netpresentvalue")]
        public IHttpActionResult Calculate([FromBody]NetPresentValueView netPresentValueView)
        {
            var npv = Mapper.Map<NetPresentValueView, NetPresentValue>(netPresentValueView);
            var netPresentValues = this.netPresentValueService.Calculate(npv);
            var result = Mapper.Map<IEnumerable<NetPresentValueResult>, IEnumerable<NetPresentValueResultView>>(netPresentValues);
            return this.Ok(result);
        }

        [HttpGet]
        [Route("api/netpresentvalue")]
        public IHttpActionResult GetAll()
        {
            var netPresentValues = this.netPresentValueService.GetNetPresentValues();
            var result = Mapper.Map<IEnumerable<NetPresentValue>, IEnumerable<NetPresentValueView>>(netPresentValues);
            return this.Ok(result);
        }

        [HttpDelete]
        [Route("api/netpresentvalue/{id}/delete")]
        public IHttpActionResult Delete(int id)
        {
            this.netPresentValueService.DeleteNPV(id);
            return this.Ok();
        }
    }
}