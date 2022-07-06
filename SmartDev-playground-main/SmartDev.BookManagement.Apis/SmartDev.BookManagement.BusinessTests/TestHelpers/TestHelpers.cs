using Moq;
using Moq.EntityFrameworkCore;
using SmartDev.BookManagement.DB;
using SmartDev.BookManagement.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDev.BookManagement.BusinessTests
{
    public class TestHelpers
    {
        public static Mock<BookMngDbContext> CreateMockBookDb()
        {
            var userData = CreateFakeUserData();
            var bookData = CreateFakeBookData();
            var userbookData = CreateFakeUserBookData();

            var mockDB = new Mock<BookMngDbContext>();
            mockDB.SetupGet(x => x.Users).ReturnsDbSet(userData);
            mockDB.SetupGet(x => x.Books).ReturnsDbSet(bookData);
            mockDB.SetupGet(x => x.UserBookRelations).ReturnsDbSet(userbookData);

            return mockDB;
        }

        private static List<UserBookRelationEntity> CreateFakeUserBookData()
        {
            var bookData = new List<UserBookRelationEntity>()
            {
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000001"), RelationType = Entities.Enums.RelationTypeEnum.Read, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000002"), RelationType = Entities.Enums.RelationTypeEnum.Read, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000003"), RelationType = Entities.Enums.RelationTypeEnum.Read, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000004"), RelationType = Entities.Enums.RelationTypeEnum.Read, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000005"), RelationType = Entities.Enums.RelationTypeEnum.Read, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000006"), RelationType = Entities.Enums.RelationTypeEnum.ReadComplete, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000007"), RelationType = Entities.Enums.RelationTypeEnum.ReadComplete, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000008"), RelationType = Entities.Enums.RelationTypeEnum.ReadComplete, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000009"), RelationType = Entities.Enums.RelationTypeEnum.ReadComplete, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000010"), RelationType = Entities.Enums.RelationTypeEnum.ReadComplete, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000011"), RelationType = Entities.Enums.RelationTypeEnum.ReadComplete, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000012"), RelationType = Entities.Enums.RelationTypeEnum.ReadComplete, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000013"), RelationType = Entities.Enums.RelationTypeEnum.Favorite, Id = Guid.NewGuid() },
                new UserBookRelationEntity() { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BookId = Guid.Parse("00000000-0000-0000-0000-000000000014"), RelationType = Entities.Enums.RelationTypeEnum.Favorite, Id = Guid.NewGuid() },
            };
            return bookData;
        }

        private static List<BookEntity> CreateFakeBookData()
        {
            var bookData = new List<BookEntity>()
            {
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Northanger Abbey", Author = "Austen, Jane" },
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "War and Peace", Author = "Tolstoy, Leo" },
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "War and Peace 2", Author = "Tolstoy, Leo" },
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Anna Karenina", Author= "Tolstoy, Leo" },
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Mrs. Dalloway", Author= "Woolf, Virginia" },
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "The Hours", Author= "Cunnningham, Michael" },
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Huckleberry Finn", Author = "Twain, Mark"},
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Bleak House", Author = "Dickens, Charles"},
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Tom Sawyer", Author = "Twain, Mark"},
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "A Room of One's Own", Author = "Woolf, Virginia"},
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Harry Potter", Author = "Rowling, J.K."},
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "One Hundred Years of Solitude", Author = "Marquez"},
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Hamlet, Prince of Denmark", Author = "Shakespeare"},
                new BookEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "Lord of the Rings", Author = "Tolkien, J.R." }
            };
    
            return bookData;
        }
        private static List<UserEntity> CreateFakeUserData()
        {
            var userData = new List<UserEntity>()
            {
                new UserEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), UserName = "Northanger", Name = "Austen, Jane" },
                new UserEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), UserName = "Tolstoy", Name = "Tolstoy, Leo" },
                new UserEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), UserName = "Woolf", Name= "Woolf, Virginia" },
                new UserEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), UserName = "Cunnningham", Name = "Cunnningham, Michael" },
                new UserEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), UserName = "Twain", Name = "Twain, Mark"},
                new UserEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), UserName = "Dickens", Name = "Dickens, Charles"},
                new UserEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), UserName = "Sawyer", Name = "Tom Sawyer"},
                new UserEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), UserName = "Woolf", Name = "Woolf, Virginia"},
                new UserEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), UserName = "Rowling", Name = "Rowling, J.K."},
                new UserEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), UserName = "Marquez", Name = "Marquez"},
                new UserEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), UserName = "Hamlet", Name = "Shakespeare"},
                new UserEntity() { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), UserName = "Tolkien", Name = "Tolkien, J.R." }
            };

            return userData;
        }
    }
}
