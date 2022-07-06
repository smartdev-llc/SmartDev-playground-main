using Microsoft.EntityFrameworkCore;
using SmartDev.BookManagement.Entities;

namespace SmartDev.BookManagement.DB
{
    public class BookMngDbContext : DbContext
    {
        public BookMngDbContext() { }

        public BookMngDbContext(DbContextOptions<BookMngDbContext> options) : base(options) { }

        public virtual DbSet<UserEntity> Users { get; set; } 
        public virtual DbSet<BookEntity> Books { get; set; }
        public virtual DbSet<UserBookRelationEntity> UserBookRelations { get; set; } 

    }
}
