using BookLib.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLib.DataAccess
{
   public class BookLibSqlContext : DbContext
   {
      public BookLibSqlContext(DbContextOptions<BookLibSqlContext> options) : base(options)
      {
      }
      public DbSet<Author> Authors { get; set; }
      public DbSet<Book> Books { get; set; }
      public DbSet<BookAuthor> BookAuthors { get; set; }
      public DbSet<Genre> Genres { get; set; } 
      public DbSet<Image> Images { get; set; }
      public DbSet<Publisher> Publishers { get; set; }
   }
}
