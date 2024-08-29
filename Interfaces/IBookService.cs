using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore_Project.Models;

namespace BookStore_Project.Interfaces
{
	public interface IBookService
	{
		Task<IEnumerable<Book>> GetBooksAsync();
		Task<Book?> GetBookByIdAsync(int id);
		Task<Book> CreateBookAsync(Book book);
		Task UpdateBookAsync(int id, Book book);
		Task DeleteBookAsync(int id);
		Task<IEnumerable<Book>> SearchBooksAsync(string title, string author, string genre);
	}
}