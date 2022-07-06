using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDev.BookManagement.Entities
{
    /// <summary>
    /// The user entity.
    /// </summary>
    public class UserEntity: BaseEntity
    {
        /// <summary>
        /// The user id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        /// <summary>
        /// The user name.  
        /// </summary>
        [Required]
        [StringLength(50)]
        public virtual string UserName { get; set; }

        /// <summary>
        /// The name.
        /// </summary>
        [Required]
        [StringLength(128)]
        public virtual string Name { get; set; }

        /// <summary>
        /// The user password.
        /// </summary>
        [StringLength(1024)]
        public virtual string Password { get; set; }

        /// <summary>
        /// The password salt.
        /// </summary>
        [StringLength(1024)]
        public virtual string PasswordSalt { get; set; }
    }
}
