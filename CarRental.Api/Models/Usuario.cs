using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Api.Models;

[Table("Usuario")]
public class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("NombreUsuario")]
    [MaxLength(50)]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required]
    [Column("Correo")]
    [MaxLength(100)]
    public string Correo { get; set; } = string.Empty;

    public ICollection<Alquiler> Alquileres { get; set; }
        = new List<Alquiler>();
}