﻿using BookLib.DataAccess;
using BookLib.Entities;

namespace BookLib.Repositories
{
	public class GenreRepository
	{

		private readonly BookLibSqlContext _context;

        public GenreRepository(BookLibSqlContext context)
        {
            this._context = context;
        }

        public List<Genre> GetAll() 
        {
            return this._context.Genres.ToList();
        }

        public int AddGenre(Genre genre)
        {
            this._context.Genres.Add(genre);

            this._context.SaveChanges();

            return genre.GenreId;
        }
    }
}
