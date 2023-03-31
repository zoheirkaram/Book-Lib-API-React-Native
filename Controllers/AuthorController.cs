using BookLib.Entities;
using BookLib.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookLib.Controllers
{
	[Route("api/authors")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		public AuthorRepository AuthorRepository { get; set; }

        public AuthorController(AuthorRepository authorRepository)
        {
            this.AuthorRepository = authorRepository;
        }

		[HttpGet]
		public IActionResult GetAllAuthors()
		{
			try
			{
				var result = this.AuthorRepository.GetAll();

				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException?.Message ?? ex.Message);
			}
		}

		[HttpPut]
		public IActionResult AddAuthor(Author author)
		{
			try
			{
				var result = this.AuthorRepository.AddAuthor(author);

				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException?.Message ?? ex.Message);
			}
		}
	}
}
