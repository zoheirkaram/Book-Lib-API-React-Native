using BookLib.DataAccess;
using BookLib.Entities;
using BookLib.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookLib.Repositories
{
	public class BookAuthorRepository
	{

		private readonly BookLibSqlContext _context;

		public BookAuthorRepository(BookLibSqlContext context)
		{
			this._context = context;
		}

		public List<Book> GetAuthorBooks(int authotId)
		{
			var bookList = this._context.BookAuthors
							.Where(ba => ba.AuthorId == authotId)
							.Include(ba => ba.Book)
								.ThenInclude(b => b.Genre)
							.Include(ba => ba.Book)
								.ThenInclude(b => b.Publisher)
							.Select(ba => ba.Book);

			return bookList.ToList();
		}

		public List<BookAuthor> GetBookAuthorsByGenreId(int genreId)
		{
			var bookAuthorsList = this._context.BookAuthors
							.Include(ba => ba.Book)
								.ThenInclude(b => b.Genre)
							.Include(ba => ba.Book)
								.ThenInclude(b => b.Publisher)
							.Include(ba => ba.Author)
							.Where(ba => ba.Book.GenreId == genreId);
							

			return bookAuthorsList.ToList();
		}

		public List<BookData> GetBookListByGenreId(int genreId)
		{
			var result = new List<BookData>();
			var books = this._context.Books
						.Where(b => b.GenreId == genreId)
						.Include(b => b.Genre)
						.Include(b => b.Publisher)
						.ToList();
			
			if (books.Any())
			{
				foreach(var book in books)
				{
					var authors = this._context.BookAuthors.Where(ba => ba.BookId == book.BookId).Select(r => r.Author).ToList();
					var images = this._context.Images.Where(i => i.BookId == book.BookId).ToList();

					result.Add(new BookData() 
					{ 						
						BookDataId = book.BookId,
						Book = book,
						Authors = authors,
						Images = images 
					});

				}
			}

			return result;

		}

		public int AddAuthorBook(BookAuthor bookAuthor)
		{
			this._context.BookAuthors.Add(bookAuthor);

			var result = this._context.SaveChanges();

			return result;
		}
	}
}
