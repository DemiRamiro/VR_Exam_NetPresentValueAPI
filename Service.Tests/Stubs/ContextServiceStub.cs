namespace Service.Tests.Stubs
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Interfaces;
    using Data.Models;

    public class ContextServiceStub : IContext<NetPresentValue>
    {
        public void Delete(NetPresentValue entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NetPresentValue> GetEntities(Func<NetPresentValue, bool> condition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NetPresentValue> GetEntities()
        {
            throw new NotImplementedException();
        }

        public NetPresentValue GetEntity(Func<NetPresentValue, bool> condition)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(NetPresentValue entity)
        {
            throw new NotImplementedException();
        }
    }
}