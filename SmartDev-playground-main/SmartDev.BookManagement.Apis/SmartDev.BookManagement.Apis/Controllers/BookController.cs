using Microsoft.AspNetCore.Mvc;
using SmartDev.BookManagement.Business;
using SmartDev.BookManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDev.BookManagement.Apis.Controllers
{
    /// <summary>
    /// The book controller.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/books")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet()]
        public async Task<IEnumerable<BookEntity>> GetBooks(string name)
        {
            return await _bookService.GetBookByName(name);
        }
    }
}
