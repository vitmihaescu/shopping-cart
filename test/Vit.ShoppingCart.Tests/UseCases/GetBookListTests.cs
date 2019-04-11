using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vit.ShoppingCart.Application.UseCases.GetBookList;
using Xunit;

namespace Vit.ShoppingCart.Tests.UseCases
{
    public class GetBookListTests : TestWithDbContext
    {
        [Fact]
        public async Task Returns_AllBooks_FromDatabase()
        {
            var handler = new BookListQueryHandler(DbContext);

            var expected = DbContext.Books.Count();
            var actual = (await handler.Handle(new BookListQuery(), CancellationToken.None)).Count;

            Assert.True(expected > 0, "The Books table is empty.");
            Assert.Equal(expected, actual);
        }
    }
}