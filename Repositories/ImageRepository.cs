using BookLib.DataAccess;
using BookLib.Entities;

namespace BookLib.Repositories
{
	public class ImageRepository
	{
		private readonly BookLibSqlContext _context;

        public ImageRepository(BookLibSqlContext bookLibSqlContext)
        {
            this._context = bookLibSqlContext;
        }

        public List<Image> GetImagesByBookId(int bookId)
        {
            return this._context.Images.Where(i => i.BookId == bookId).ToList();
        }
    }
}
