using BookLib.Entities;
using BookLib.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLib.Controllers
{
	[Route("api/genres")]
	[ApiController]
	public class GenreController : ControllerBase
	{

		public GenreRepository GenreRepository { get; }

        public GenreController(GenreRepository genreRepository)
        {
            this.GenreRepository = genreRepository;
        }

        [HttpGet]
		public IActionResult GetAllGenres()
		{
			try
			{
				var result = this.GenreRepository.GetAll();

				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException?.Message ?? ex.Message);
			}
		}

		[HttpPut]
		public IActionResult AddGenre(Genre genre)
		{
			try
			{
				var result = this.GenreRepository.AddBook(genre);

				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException?.Message ?? ex.Message);
			}
		}
	}
}
