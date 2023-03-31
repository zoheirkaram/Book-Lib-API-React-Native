using BookLib.Entities;
using BookLib.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookLib.Controllers
{
	[Route("api/publishers")]
	[ApiController]
	public class PublisherController : ControllerBase
	{
		public PublisherRepository PublisherRepository { get; set; }

		public PublisherController(PublisherRepository authorRepository)
		{
			this.PublisherRepository = authorRepository;
		}

		[HttpGet]
		public IActionResult GetAllPublishers()
		{
			try
			{
				var result = this.PublisherRepository.GetAll();

				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException?.Message ?? ex.Message);
			}
		}

		[HttpPut]
		public IActionResult AddPublisher(Publisher publisher)
		{
			try
			{
				var result = this.PublisherRepository.AddPublisher(publisher);

				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException?.Message ?? ex.Message);
			}
		}
	}
}
