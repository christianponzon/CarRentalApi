using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Api.Models;

[Table("Alquiler")]
public class Alquiler
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("UsuarioId")]
    public int UsuarioId { get; set; }

    [ForeignKey("UsuarioId")]
    public Usuario Usuario { get; set; } = null!;

    [Required]
    [Column("AutoId")]
    public int AutoId { get; set; }

    [ForeignKey("AutoId")]
    public Auto Auto { get; set; } = null!;

    [Required]
    [Column("FechaInicio")]
    public DateTime FechaInicio { get; set; }

    [Required]
    [Column("FechaFin")]
    public DateTime FechaFin { get; set; }
}