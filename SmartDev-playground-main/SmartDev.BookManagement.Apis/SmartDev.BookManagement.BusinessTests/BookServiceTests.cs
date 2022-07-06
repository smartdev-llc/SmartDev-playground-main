using SmartDev.BookManagement.Business;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SmartDev.BookManagement.BusinessTests
{
    public class BookServiceTests
    {
        BookService TestObject { get; }

        public BookServiceTests()
        {
            var mockDB = TestHelpers.CreateMockBookDb(); 

            TestObject = new BookService(mockDB.Object);
        }

        [Fact]
        public async Task BookService_When_GetBookByNameTom_Should_ReturnTomSawyer()
        {
            var result = await TestObject.GetBookByName("Tom");

            Assert.Equal(1, result.Count());
            Assert.Contains("Tom", result.First().Name);
        }

        [Fact]
        public async Task BookService_When_GetBookByNameWarandPeace_Should_Return2PartOfWarAndPeaceBooks()
        {
            var result = await TestObject.GetBookByName("War and Peace");

            Assert.Equal(2, result.Count());
            Assert.Contains("War and Peace", result.First().Name);
        }

        [Fact]
        public async Task BookService_When_GetBookByNameOz_Should_ReturnNothing()
        {
            var result = await TestObject.GetBookByName("Oz");

            Assert.Equal(0, result.Count());
        }
    }
}