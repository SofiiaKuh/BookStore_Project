using BookStore_Project.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore_Project.Models
{
	public class Author
	{
		[Key]
		public int Id { get; set; }
		public required string Name { get; set; }
		public required ICollection<Book> Books { get; set; }
	}
}
