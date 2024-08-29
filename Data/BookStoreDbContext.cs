using Microsoft.EntityFrameworkCore;
using BookStore_Project.Models;

namespace BookStore_Project.Data
{
	public class BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : DbContext(options)
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Genre> Genres { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Configure the Price property for the Book entity
			modelBuilder.Entity<Book>()
				.Property(b => b.Price)
				.HasColumnType("decimal(18,2)");
		}
	}
}
