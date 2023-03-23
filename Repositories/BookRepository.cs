
using BookLib.DataAccess;
using BookLib.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLib.Repositories
{
	public class BookRepository
	{
		private readonly BookLibSqlContext _context;

		public BookRepository(BookLibSqlContext context)
		{
			this._context = context;
		}

		public List<Book> GetAllBooks()
		{
			return this._context.Books
				.Include(b => b.Genre)
				.Include(b => b.Publisher)
				.ToList();
		}

		public List<Book> GetBooksByGenreId(int genreId)
		{
			return this._context.Books
				.Where(b => b.GenreId == genreId)
				.Include(b => b.Genre)
				.Include(b => b.Publisher)
				.ToList();
		}

		public List<Book> GetBooksByPublisherId(int publisherId)
		{
			return this._context.Books
				.Where(b => b.PublisherId == publisherId)
				.Include(b => b.Genre)
				.Include(b => b.Publisher)
				.ToList();
		}

		public Book? Get(int bookId) 
		{
			return this._context.Books
				.Where(b => b.BookId == bookId)
				.Include(b => b.Genre)
				.Include(b => b.Publisher)
				.FirstOrDefault();
		}

		public int Add(Book book)
		{
			this._context.Books.Add(book);

			var result = this._context.SaveChanges();

			return result;
		}

		public bool Update(Book book)
		{
			var result = false;
			var exitingBook = this._context.Books.Where(b => b.BookId == book.BookId).FirstOrDefault();

			if (exitingBook != null)
			{
				this._context.Entry(exitingBook).CurrentValues.SetValues(book);
				result = this._context.SaveChanges() > 0;
			}

			return result;
		}
	}
}