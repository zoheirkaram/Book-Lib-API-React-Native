using BookLib.DataAccess;
using BookLib.Entities;

namespace BookLib.Repositories
{
	public class PublisherRepository
	{
		private readonly BookLibSqlContext _context;

        public PublisherRepository(BookLibSqlContext context)
        {
            this._context = context;
        }

        public List<Publisher> GetAll()
        {
            return this._context.Publishers.ToList();
        }
    }
}
