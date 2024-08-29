using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore_Project.Data;
using BookStore_Project.Models;
using BookStore_Project.Interfaces;

namespace BookStore_Project.Services
{
	public class BookService(BookStoreDBContext context) : IBookService
	{
		private readonly BookStoreDBContext _context = context;

		public async Task<IEnumerable<Book>> GetBooksAsync()
		{
			return await _context.Books.Include(b => b.Author).Include(b => b.Genre).ToListAsync();
		}

		public async Task<Book?> GetBookByIdAsync(int id)
		{
			return await _context.Books.Include(b => b.Author).Include(b => b.Genre)
				.FirstOrDefaultAsync(b => b.Id == id);
		}

		public async Task<Book> CreateBookAsync(Book book)
		{
			_context.Books.Add(book);
			await _context.SaveChangesAsync();
			return book;
		}

		public async Task UpdateBookAsync(int id, Book book)
		{
			if (id != book.Id)
			{
				throw new ArgumentException("ID mismatch");
			}

			_context.Entry(book).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteBookAsync(int id)
		{
			var book = await _context.Books.FindAsync(id);
			if (book != null)
			{
				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Book>> SearchBooksAsync(string title, string author, string genre)
		{
			var query = _context.Books.AsQueryable();

			if (!string.IsNullOrEmpty(title))
			{
				query = query.Where(b => b.Title.Contains(title));
			}

			if (!string.IsNullOrEmpty(author))
			{
				query = query.Where(b => b.Author.Name.Contains(author));
			}

			if (!string.IsNullOrEmpty(genre))
			{
				query = query.Where(b => b.Genre.Name.Contains(genre));
			}

			return await query.Include(b => b.Author).Include(b => b.Genre).ToListAsync();
		}
	}
}