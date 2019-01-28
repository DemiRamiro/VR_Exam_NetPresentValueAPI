namespace Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SqlEntity
    {
        public SqlEntity()
        {
            this.Created = DateTime.UtcNow;
            this.LastModified = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime LastModified { get; set; }
    }
}