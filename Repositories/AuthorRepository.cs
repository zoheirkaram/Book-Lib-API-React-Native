using BookLib.DataAccess;
using BookLib.Entities;

namespace BookLib.Repositories
{
	public class AuthorRepository
	{
		private readonly BookLibSqlContext _context;

        public AuthorRepository(BookLibSqlContext context)
        {
            this._context = context;
        }

		public List<Author> GetAll()
		{
			return this._context.Authors.ToList();
		}

		public int AddAuthor(Author author)
		{
			this._context.Authors.Add(author);

			this._context.SaveChanges();

			return author.AuthorId;
		}
	}
}
