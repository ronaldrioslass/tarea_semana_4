using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tarea_semana_4.Models;

public class Libro
{
    [Key]
    [Display(Name = "Código")]
    public int IdLibro { get; set; }

    [Display(Name = "Título")]
    [Required(ErrorMessage = "El título es obligatorio")]
    [StringLength(120, ErrorMessage = "Máximo 120 caracteres")]
    public string Titulo { get; set; } = string.Empty;

    [Range(0, 1000, ErrorMessage = "El stock debe estar entre 0 y 1000")]
    public int Stock { get; set; }

    [Display(Name = "Autor")]
    public int IdAutor { get; set; }

    [Display(Name = "Categoría")]
    public int IdCategoria { get; set; }

    [ForeignKey(nameof(IdAutor))]
    public Autor? Autor { get; set; }

    [ForeignKey(nameof(IdCategoria))]
    [Display(Name = "Categoría")]
    public Categoria? Categoria { get; set; }

    public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
