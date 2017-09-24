using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace BooksUnlimited.Services.BooksCatalog.Abstractions
{
    public interface IBooksCatalogService : IService
    {
        Task<IList<Book>> GetBooksAsync();
    }
}
