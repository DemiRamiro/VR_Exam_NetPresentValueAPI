namespace Data
{
    using System.Data.Entity;
    using Data.Models;

    public class DataContext : DbContext
    {
        public DataContext() : base("name=DatabaseContext")
        {

        }
        public virtual DbSet<NetPresentValue> NetPresentValues { get; set; }
    }
}