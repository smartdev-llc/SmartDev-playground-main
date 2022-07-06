using SmartDev.BookManagement.Entities;
using SmartDev.BookManagement.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDev.BookManagement.Business
{
    public interface IUserBookRelationRepository
    {
        Task AddBookToUserList(Guid userId, Guid bookId, RelationTypeEnum relationType);
        Task<IEnumerable<Guid>> GetUserBooks(Guid userId, RelationTypeEnum? relationType);
    } 
}
