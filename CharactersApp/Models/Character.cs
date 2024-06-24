using System.ComponentModel.DataAnnotations;

namespace CharactersApp.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        public string firstName { get; set; }

        public string description { get; set; }

        public string comment { get; set; }
    }
}
