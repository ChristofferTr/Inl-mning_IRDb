using System.ComponentModel.DataAnnotations;

namespace Inlämning_IRDb
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Director { get; set; }

        [Range(1900, 2100)]
        public int Year { get; set; }

        [MaxLength(50)]
        public string? Genre { get; set; }

        [Range(1, 300)]
        public int Duration { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        public string ImageUrl { get; set; }
    }
}
