namespace Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;

    public interface IContext<T> where T : SqlEntity
    {
        Task InsertAsync(T entity);

        T GetEntity(Func<T, bool> condition);

        IEnumerable<T> GetEntities(Func<T, bool> condition);

        IEnumerable<T> GetEntities();

        void Delete(T entity);
    }
}