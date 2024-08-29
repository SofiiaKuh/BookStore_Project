using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore_Project.Models;

namespace BookStore_Project.Interfaces
{
	public interface IAuthorService
	{
		Task<IEnumerable<Author>> GetAuthorsAsync();
		Task<Author?> GetAuthorByIdAsync(int id);
		Task<Author> CreateAuthorAsync(Author author);
		Task UpdateAuthorAsync(int id, Author author);
		Task DeleteAuthorAsync(int id);
	}
}