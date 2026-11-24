using System.ComponentModel.DataAnnotations;

namespace CarRental.Api.Dto
{
    public class AutoDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Marca { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Year { get; set; }
    }
}