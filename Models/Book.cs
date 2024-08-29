using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore_Project.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }
		public required string Title { get; set; }
		public required int AuthorId { get; set; }
		public required int GenreId { get; set; }
		public required decimal Price { get; set; }
		public required int QuantityAvailable { get; set; }

		[ForeignKey(nameof(AuthorId))]
		public required Author Author { get; set; }

		[ForeignKey(nameof(GenreId))]
		public required Genre Genre { get; set; }
	}
}
