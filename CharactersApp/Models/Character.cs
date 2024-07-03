using System.ComponentModel.DataAnnotations;

namespace CharactersApp.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string firstName { get; set; }

		[Required]
		public string description { get; set; }

		[Required]
		public string comment { get; set; }
    }
}
