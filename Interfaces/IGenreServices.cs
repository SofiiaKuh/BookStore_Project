using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore_Project.Models;

namespace BookStore_Project.Interfaces
{
	public interface IGenreService
	{
		Task<IEnumerable<Genre>> GetGenresAsync();
		Task<Genre?> GetGenreByIdAsync(int id);
		Task<Genre> CreateGenreAsync(Genre genre);
		Task UpdateGenreAsync(int id, Genre genre);
		Task DeleteGenreAsync(int id);
	}
}