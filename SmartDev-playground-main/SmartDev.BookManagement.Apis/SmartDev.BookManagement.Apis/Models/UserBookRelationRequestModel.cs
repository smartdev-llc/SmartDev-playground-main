using SmartDev.BookManagement.Entities.Enums;
using System;

namespace SmartDev.BookManagement.Apis.Models
{
    public class UserBookRelationRequestModel
    {
        public Guid BookId { get; set; }
        public RelationTypeEnum RelationType { get; set; }
    }
}
