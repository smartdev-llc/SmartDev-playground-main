using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDev.BookManagement.Entities
{
    /// <summary>
    /// The book entity.
    /// </summary>
    public class BookEntity: BaseEntity
    {
        /// <summary>
        /// The book id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }
        public virtual string Summary { get; set; }
        public virtual string Author { get; set; }
        //...
    }
}