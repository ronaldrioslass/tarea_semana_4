using System.ComponentModel.DataAnnotations;

namespace tarea_semana_4.Models;

public class Categoria
{
    [Key]
    [Display(Name = "Código")]
    public int IdCategoria { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    [Display(Name = "Descripción")]
    [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El pasillo es obligatorio")]
    [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
    public string Pasillo { get; set; } = string.Empty;

    public bool Activa { get; set; }

    public ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
