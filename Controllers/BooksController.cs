using Microsoft.AspNetCore.Mvc;
using BookLib.Entities;
using BookLib.Repositories;
using BookLib.Services;

namespace BookLib.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
	private readonly ILogger<BooksController> _logger;
	public BookRepository BookRepository { get; }
	public BookAuthorRepository BookAuthorsRepository { get; }
	public ImageRepository ImageRepository { get; }
	public OpenLibraryService OpenLibraryService { get; }

   public BooksController(ILogger<BooksController> logger, 
						  BookRepository booksRepository, 
						  BookAuthorRepository bookAuthorsRepository,
						  ImageRepository imageRepository,
					      OpenLibraryService openLibraryService)
	{
		_logger = logger;
		this.BookRepository = booksRepository;
		this.BookAuthorsRepository = bookAuthorsRepository;
		this.ImageRepository = imageRepository;
		this.OpenLibraryService = openLibraryService;
	}

	[HttpGet]
	public IActionResult Get()
	{
		try
		{
			var result = this.BookRepository.GetAllBooks();

			return Ok(result);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.InnerException?.Message ?? ex.Message);
		}
	}

	[HttpGet]
	[Route("{bookId}")]
	public IActionResult Get([FromRoute] int bookId)
	{
		try
		{
			var result = this.BookRepository.Get(bookId);

			return Ok(result);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.InnerException?.Message ?? ex.Message);
		}
	}

	[HttpGet]
	[Route("genre/{genreId}")]
	public IActionResult GetBooksByGenreId([FromRoute] int genreId)
	{
		try
		{
			var result = this.BookRepository.GetBooksByGenreId(genreId);

			return Ok(result);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.InnerException?.Message ?? ex.Message);
		}
	}

	[HttpGet]
	[Route("publisher/{publisherId}")]
	public IActionResult GetBooksByPublisherId([FromRoute] int publisherId)
	{
		try
		{
			var result = this.BookRepository.GetBooksByPublisherId(publisherId);

			return Ok(result);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.InnerException?.Message ?? ex.Message);
		}
	}


	[HttpPut]
	public IActionResult AddBook(Book book)
	{
		try
		{
			var result = this.BookRepository.Add(book);

			return Ok(result);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.InnerException?.Message ?? ex.Message);
		}
	}

	[HttpPost]
	public IActionResult UpdateBook(Book book)
	{
		try
		{
			var result = this.BookRepository.Update(book);

			return Ok(result);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.InnerException?.Message ?? ex.Message);
		}
	}

	[HttpGet]
	[Route("author/{authorId}")]
	public IActionResult GetAuthorBooks([FromRoute] int authorId)
	{
		try
		{
			var result = this.BookAuthorsRepository.GetAuthorBooks(authorId);

			return Ok(result);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.InnerException?.Message ?? ex.Message);
		}
	}

	[HttpGet]
	[Route("list/genre/{genreId}")]
	public IActionResult GetBookListByGenreId([FromRoute] int genreId)
	{
		try
		{
			var result = this.BookAuthorsRepository.GetBookListByGenreId(genreId);

			return Ok(result);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.InnerException?.Message ?? ex.Message);
		}
	}

	[HttpGet]
	[Route("images/{bookId}")]
	public IActionResult GetImagesByBookId([FromRoute] int bookId)
	{
		try
		{
			var result = this.ImageRepository.GetImagesByBookId(bookId);

			return Ok(result);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.InnerException?.Message ?? ex.Message);
		}
	}

	[HttpGet]
	[Route("openlibrary/{isbn}")]
	public async Task<IActionResult> GetLibraryBookDetails([FromRoute] string isbn)
	{
		try
		{
			var result = await this.OpenLibraryService.GetLibraryBookDetailsAsync(isbn);

			return Ok(result);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.InnerException?.Message ?? ex.Message);
		}
	}
}
