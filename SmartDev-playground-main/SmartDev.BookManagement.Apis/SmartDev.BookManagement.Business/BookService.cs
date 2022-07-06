using Microsoft.EntityFrameworkCore;
using SmartDev.BookManagement.Business.Models;
using SmartDev.BookManagement.DB;
using SmartDev.BookManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDev.BookManagement.Business
{
    public class BookService : IBookService
    {
        private readonly BookMngDbContext _dbContext;

        public BookService(BookMngDbContext dbContext)
        {
            _dbContext = dbContext;
        }
          
        public async Task<IEnumerable<BookEntity>> GetBookByName(string nameQuery)
        {
            var res = _dbContext.Books.Where(x => string.IsNullOrEmpty(nameQuery) || x.Name.Contains(nameQuery));
            return await res.ToListAsync();
        }
        public async Task<IEnumerable<BookEntity>> GetBookByIds(IEnumerable<Guid> listIds)
        {
            var res = _dbContext.Books.Where(x => listIds.Contains(x.Id));
            return await res.ToListAsync();
        }
    }
}
