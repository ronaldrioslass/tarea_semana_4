using System.ComponentModel.DataAnnotations;

namespace tarea_semana_4.Models;

public class Estudiante
{
    [Key]
    [Display(Name = "Código")]
    public int IdEstudiante { get; set; }

    [Display(Name = "Cédula")]
    [Required(ErrorMessage = "La cédula es obligatoria")]
    [RegularExpression("^[0-9]{10}$", ErrorMessage = "La cédula debe tener 10 números")]
    public string Cedula { get; set; } = string.Empty;

    [Required(ErrorMessage = "Los nombres son obligatorios")]
    [StringLength(60, ErrorMessage = "Máximo 60 caracteres")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "Los apellidos son obligatorios")]
    [StringLength(60, ErrorMessage = "Máximo 60 caracteres")]
    public string Apellidos { get; set; } = string.Empty;

    [Required(ErrorMessage = "El curso es obligatorio")]
    [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
    public string Curso { get; set; } = string.Empty;

    public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
