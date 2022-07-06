using SmartDev.BookManagement.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDev.BookManagement.Entities
{
    public class UserBookRelationEntity : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        [Required]
        public virtual Guid BookId { get; set; }


        [Required]
        public virtual Guid UserId { get; set; }

        [NotMapped]
        public virtual RelationTypeEnum RelationType { get; set; }

        public virtual string RelationTypeValue
        {
            get
            {
                return RelationType.ToString();

            }
            set
            {
                if (!Enum.TryParse(value, out RelationTypeEnum RelationType))
                {
                    RelationType = RelationTypeEnum.Undefined;
                }
            }
        }

    }
}
