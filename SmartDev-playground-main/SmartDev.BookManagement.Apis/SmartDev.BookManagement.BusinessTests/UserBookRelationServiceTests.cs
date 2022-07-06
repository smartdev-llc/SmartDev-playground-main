using Moq;
using SmartDev.BookManagement.Business;
using SmartDev.BookManagement.DB;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SmartDev.BookManagement.BusinessTests
{
    public class UserBookRelationServiceTests
    {
        UserBookRelationService TestObject { get; }
        Mock<BookMngDbContext> mockDB { get; }

        public UserBookRelationServiceTests()
        {
            mockDB = TestHelpers.CreateMockBookDb();

            var bookService = new BookService(mockDB.Object);
            var userBookRelationRepository = new UserBookRelationRepository(mockDB.Object);

            TestObject = new UserBookRelationService(bookService, userBookRelationRepository);
        }

        [Fact]
        public async Task UserBookRelationService_When_AddBookToUserList_Then_SaveShouldBeCalled()
        {
            var userId = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var bookId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            await TestObject.AddBookToUserList(userId, bookId, Entities.Enums.RelationTypeEnum.ReadComplete);

            mockDB.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task UserBookRelationService_When_GetBooksByAnUser_Should_ReturnListOfBooks()
        {
            var userId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var result = await TestObject.GetUserBooks(userId, null);

            Assert.Equal(14, result.Count());
        }

        [Fact]
        public async Task UserBookRelationService_When_GetBooksByAnUserWhichWereReadCompletely_Should_ReturnListOfBooks()
        {
            var userId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var result = await TestObject.GetUserBooks(userId, Entities.Enums.RelationTypeEnum.ReadComplete);

            Assert.Equal(7, result.Count());
        }
    }
}