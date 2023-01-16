using System.ComponentModel.DataAnnotations;

namespace aspcoremariadb.Models
{
    public class Book
    {
       
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }

        [Required]
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
