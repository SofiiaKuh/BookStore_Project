using Microsoft.AspNetCore.Mvc;
using BookStore_Project.Models;
using BookStore_Project.Interfaces;

namespace BookStore_Project.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenresController(IGenreService genreService) : ControllerBase
	{
		private readonly IGenreService _genreService = genreService;

		// GET: api/Genres
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Genre?>>> GetGenres()
		{
			var genres = await _genreService.GetGenresAsync();
			return Ok(genres);
		}

		// GET: api/Genres/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Genre?>> GetGenre(int id)
		{
			var genre = await _genreService.GetGenreByIdAsync(id);
			if (genre == null)
			{
				return NotFound();
			}

			return Ok(genre);
		}

		// POST: api/Genres
		[HttpPost]
		public async Task<ActionResult<Genre?>> PostGenre(Genre genre)
		{
			var createdGenre = await _genreService.CreateGenreAsync(genre);
			return CreatedAtAction(nameof(GetGenre), new { id = createdGenre.Id }, createdGenre);
		}

		// PUT: api/Genres/5
		[HttpPut("{id}")]
		public async Task<IActionResult?> PutGenre(int id, Genre genre)
		{
			try
			{
				await _genreService.UpdateGenreAsync(id, genre);
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}

			return NoContent();
		}

		// DELETE: api/Genres/5
		[HttpDelete("{id}")]
		public async Task<IActionResult?> DeleteGenre(int id)
		{
			await _genreService.DeleteGenreAsync(id);
			return NoContent();
		}
	}
}