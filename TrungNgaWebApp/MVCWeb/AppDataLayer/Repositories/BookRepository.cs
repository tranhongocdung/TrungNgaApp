using MVCWeb.AppDataLayer.Entities;
using MVCWeb.AppDataLayer.IRepositories;

namespace MVCWeb.AppDataLayer.Repositories
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