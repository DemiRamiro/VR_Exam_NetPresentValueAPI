namespace Service.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Interfaces;
    using Data.Models;

    public class ContextService<T> : IContext<T> where T : SqlEntity
    {
        private readonly DataContext context;

        public ContextService()
        {
            if (this.context == null)
            {
                this.context = new DataContext();
            }
        }

        public void Delete(T entity)
        {
            this.context.Entry(entity).State = EntityState.Deleted;
            this.context.SaveChanges();
        }

        public IEnumerable<T> GetEntities(Func<T, bool> condition)
        {
            var entities = this.context.Set<T>().ToList().Where(condition);
            return entities;
        }

        public IEnumerable<T> GetEntities()
        {
            var entities = this.context.Set<T>().ToList();
            return entities;
        }

        public T GetEntity(Func<T, bool> condition)
        {
            var entity = this.context.Set<T>().ToList().FirstOrDefault(condition);
            return entity;
        }

        public async Task InsertAsync(T entity)
        {
            try
            {
                this.context.Set<T>().Add(entity);
                await this.context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception("An error occured during entity validation.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while inserting data to database.", ex);
            }
        }
    }
}