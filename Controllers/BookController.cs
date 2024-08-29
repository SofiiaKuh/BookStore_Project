using Microsoft.AspNetCore.Mvc;
using BookStore_Project.Models;
using BookStore_Project.Interfaces;

namespace BookStore_Project.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController(IBookService bookService) : ControllerBase
	{
		private readonly IBookService _bookService = bookService;

		// GET: api/Books
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Book?>>> GetBooks()
		{
			var books = await _bookService.GetBooksAsync();
			return Ok(books);
		}

		// GET: api/Books/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Book?>> GetBook(int id)
		{
			var book = await _bookService.GetBookByIdAsync(id);
			if (book == null)
			{
				return NotFound();
			}

			return Ok(book);
		}

		// POST: api/Books
		[HttpPost]
		public async Task<ActionResult<Book?>> PostBook(Book book)
		{
			var createdBook = await _bookService.CreateBookAsync(book);
			return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
		}

		// PUT: api/Books/5
		[HttpPut("{id}")]
		public async Task<IActionResult?> PutBook(int id, Book book)
		{
			try
			{
				await _bookService.UpdateBookAsync(id, book);
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}

			return NoContent();
		}

		// DELETE: api/Books/5
		[HttpDelete("{id}")]
		public async Task<IActionResult?> DeleteBook(int id)
		{
			await _bookService.DeleteBookAsync(id);
			return NoContent();
		}

		// GET: api/Books/search?title=title&author=author&genre=genre
		[HttpGet("search")]
		public async Task<ActionResult<IEnumerable<Book?>>> SearchBooks([FromQuery] string title, [FromQuery] string author, [FromQuery] string genre)
		{
			var books = await _bookService.SearchBooksAsync(title, author, genre);
			return Ok(books);
		}
	}
}