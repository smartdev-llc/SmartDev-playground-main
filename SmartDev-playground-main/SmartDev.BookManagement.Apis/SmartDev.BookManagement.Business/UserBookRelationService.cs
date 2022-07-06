using SmartDev.BookManagement.Entities;
using SmartDev.BookManagement.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDev.BookManagement.Business
{
    public class UserBookRelationService : IUserBookRelationService
    {
        private readonly IBookService _bookService;
        private readonly IUserBookRelationRepository _userBookRelationRepository;

        public UserBookRelationService(IBookService bookService, IUserBookRelationRepository userBookRelationRepository)
        {
            _bookService = bookService;
            _userBookRelationRepository = userBookRelationRepository;
        }

        public async Task AddBookToUserList(Guid userId, Guid bookId, RelationTypeEnum relationType)
        {
            await _userBookRelationRepository.AddBookToUserList(userId, bookId, relationType);
        }

        public async Task<IEnumerable<BookEntity>> GetUserBooks(Guid userId, RelationTypeEnum? relationType)
        {
            var userBookIds = await _userBookRelationRepository.GetUserBooks(userId, relationType);

            var books = await _bookService.GetBookByIds(userBookIds);
            return books;
        }
    }
}
