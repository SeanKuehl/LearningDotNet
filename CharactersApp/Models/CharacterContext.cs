using Microsoft.EntityFrameworkCore;

namespace CharactersApp.Models
{
	public class CharacterContext : DbContext
	{
		public DbSet<Character> Characters { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlite(@"Data Source=C:\Users\turqo\source\repos\CharactersApp\CharactersApp\DB\Character.db");

	}
}
