using System.ComponentModel.DataAnnotations;

namespace tarea_semana_4.Models;

public class Autor
{
    [Key]
    [Display(Name = "Código")]
    public int IdAutor { get; set; }

    [Required(ErrorMessage = "Los nombres son obligatorios")]
    [StringLength(60, ErrorMessage = "Máximo 60 caracteres")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "Los apellidos son obligatorios")]
    [StringLength(60, ErrorMessage = "Máximo 60 caracteres")]
    public string Apellidos { get; set; } = string.Empty;

    [Required(ErrorMessage = "La nacionalidad es obligatoria")]
    [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
    public string Nacionalidad { get; set; } = string.Empty;

    [Display(Name = "Fecha de nacimiento")]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }

    public ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
