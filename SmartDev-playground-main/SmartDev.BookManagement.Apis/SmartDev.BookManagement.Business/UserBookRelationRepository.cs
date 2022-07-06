using Microsoft.EntityFrameworkCore;
using SmartDev.BookManagement.DB;
using SmartDev.BookManagement.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDev.BookManagement.Business
{
    public class UserBookRelationRepository : IUserBookRelationRepository
    {
        private readonly BookMngDbContext _dbContext;

        public UserBookRelationRepository(BookMngDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBookToUserList(Guid userId, Guid bookId, RelationTypeEnum relationType)
        {
            var exist = await _dbContext.UserBookRelations
                .Where(x => x.UserId == userId && x.BookId == bookId)
                .FirstOrDefaultAsync();

            if (exist == null)
            {
                _dbContext.UserBookRelations.Add(new Entities.UserBookRelationEntity()
                {
                    UserId = userId,
                    BookId = bookId,
                    RelationType = relationType
                });
            }
            else
            {
                exist.RelationType = relationType;
                _dbContext.UserBookRelations.Update(exist);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Guid>> GetUserBooks(Guid userId, RelationTypeEnum? relationType)
        {
            var query = _dbContext.UserBookRelations.Where(x => x.UserId == userId);

            if (relationType != null)
            {
                query = query.Where(x => x.RelationTypeValue == relationType.ToString());
            }

            try
            {
                return await query
                    .Select(x => x.BookId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            } 
        }
    }
}
