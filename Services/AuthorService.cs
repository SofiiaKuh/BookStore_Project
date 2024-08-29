using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore_Project.Data;
using BookStore_Project.Models;
using BookStore_Project.Interfaces;

namespace BookStore_Project.Services
{
	public class AuthorService(BookStoreDBContext context) : IAuthorService
	{
		private readonly BookStoreDBContext _context = context;

		public async Task<IEnumerable<Author>> GetAuthorsAsync()
		{
			return await _context.Authors.ToListAsync();
		}

		public async Task<Author?> GetAuthorByIdAsync(int id)
		{
			return await _context.Authors.FindAsync(id);
		}

		public async Task<Author> CreateAuthorAsync(Author author)
		{
			_context.Authors.Add(author);
			await _context.SaveChangesAsync();
			return author;
		}

		public async Task UpdateAuthorAsync(int id, Author author)
		{
			if (id != author.Id)
			{
				throw new ArgumentException("ID mismatch");
			}

			_context.Entry(author).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAuthorAsync(int id)
		{
			var author = await _context.Authors.FindAsync(id);
			if (author != null)
			{
				_context.Authors.Remove(author);
				await _context.SaveChangesAsync();
			}
		}
	}
}