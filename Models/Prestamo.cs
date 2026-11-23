using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tarea_semana_4.Models;

public class Prestamo
{
    [Key]
    [Display(Name = "Código")]
    public int IdPrestamo { get; set; }

    [Display(Name = "Fecha de préstamo")]
    [DataType(DataType.Date)]
    public DateTime FechaPrestamo { get; set; }

    [Display(Name = "Fecha de devolución")]
    [DataType(DataType.Date)]
    public DateTime? FechaDevolucion { get; set; }

    [Display(Name = "Libro")]
    public int IdLibro { get; set; }

    [Display(Name = "Estudiante")]
    public int IdEstudiante { get; set; }

    [ForeignKey(nameof(IdLibro))]
    public Libro? Libro { get; set; }

    [ForeignKey(nameof(IdEstudiante))]
    public Estudiante? Estudiante { get; set; }
}
