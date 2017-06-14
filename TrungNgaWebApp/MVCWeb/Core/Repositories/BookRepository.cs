using MVCWeb.Core.Entities;
using MVCWeb.Core.IRepositories;

namespace MVCWeb.Core.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly IDbAppContext _context;

        public BookRepository(IDbAppContext context) : base(context)
        {
            _context = context as DbAppContext;
        }
    }
}