using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore_Project.Data;
using BookStore_Project.Models;
using BookStore_Project.Interfaces;

namespace BookStore_Project.Services
{
	public class GenreService(BookStoreDBContext context) : IGenreService
	{
		private readonly BookStoreDBContext _context = context;

		public async Task<IEnumerable<Genre>> GetGenresAsync()
		{
			return await _context.Genres.ToListAsync();
		}

		public async Task<Genre?> GetGenreByIdAsync(int id)
		{
			return await _context.Genres.FindAsync(id);
		}

		public async Task<Genre> CreateGenreAsync(Genre genre)
		{
			_context.Genres.Add(genre);
			await _context.SaveChangesAsync();
			return genre;
		}

		public async Task UpdateGenreAsync(int id, Genre genre)
		{
			if (id != genre.Id)
			{
				throw new ArgumentException("ID mismatch");
			}

			_context.Entry(genre).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteGenreAsync(int id)
		{
			var genre = await _context.Genres.FindAsync(id);
			if (genre != null)
			{
				_context.Genres.Remove(genre);
				await _context.SaveChangesAsync();
			}
		}
	}
}