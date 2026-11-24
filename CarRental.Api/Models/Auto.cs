using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Api.Models;

[Table("Auto")]
public class Auto
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("Marca")]
    [MaxLength(30)]
    public string Marca { get; set; } = string.Empty;

    [Required]
    [Column("Modelo")]
    [MaxLength(30)]
    public string Modelo { get; set; } = string.Empty;

    [Column("Precio", TypeName = "decimal(6,2)")]
    public decimal Precio { get; set; }

    [Required]
    [Column("Year")]
    public int Year { get; set; }

    public ICollection<Alquiler> Alquileres { get; set; }
        = new List<Alquiler>();
}