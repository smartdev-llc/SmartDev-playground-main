using SmartDev.BookManagement.Business.Models;
using SmartDev.BookManagement.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDev.BookManagement.Business
{
    public interface IBookService
    {
        Task<IEnumerable<BookEntity>> GetBookByName(string nameQuery);
        Task<IEnumerable<BookEntity>> GetBookByIds(IEnumerable<Guid> listIds);
    }
}
