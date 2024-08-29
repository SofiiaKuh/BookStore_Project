using Microsoft.AspNetCore.Mvc;
using BookStore_Project.Models;
using BookStore_Project.Interfaces;

namespace BookStore_Project.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController(IAuthorService authorService) : ControllerBase
	{
		private readonly IAuthorService _authorService = authorService;

		// GET: api/Authors
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Author?>>> GetAuthors()
		{
			var authors = await _authorService.GetAuthorsAsync();
			return Ok(authors);
		}

		// GET: api/Authors/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Author?>> GetAuthor(int id)
		{
			var author = await _authorService.GetAuthorByIdAsync(id);
			if (author == null)
			{
				return NotFound();
			}

			return Ok(author);
		}

		// POST: api/Authors
		[HttpPost]
		public async Task<ActionResult<Author?>> PostAuthor(Author author)
		{
			var createdAuthor = await _authorService.CreateAuthorAsync(author);
			return CreatedAtAction(nameof(GetAuthor), new { id = createdAuthor.Id }, createdAuthor);
		}

		// PUT: api/Authors/5
		[HttpPut("{id}")]
		public async Task<IActionResult?> PutAuthor(int id, Author author)
		{
			try
			{
				await _authorService.UpdateAuthorAsync(id, author);
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}

			return NoContent();
		}

		// DELETE: api/Authors/5
		[HttpDelete("{id}")]
		public async Task<IActionResult?> DeleteAuthor(int id)
		{
			await _authorService.DeleteAuthorAsync(id);
			return NoContent();
		}
	}
}