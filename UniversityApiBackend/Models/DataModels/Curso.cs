using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public enum Nivel { Basico, Intermedio, Avanzado }
    public class Curso:BaseEntity
    {
        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
        public string DescripcionCorta { get; set; } = string.Empty;
        public string DescripcionLarga { get; set; } = string.Empty;
        public string PublicoObjetivo { get; set; } = string.Empty;
        public string Objetivos { get; set; } = string.Empty;
        public string Requisitos { get; set; } = string.Empty;
        public Nivel Nivel { get; set; } = Nivel.Basico;

        [Required]
        public ICollection<Categoria> categorias { get; set; } = new List<Categoria>();

        [Required]
        public Tema Tema { get; set; } = new Tema();

        [Required]
        public ICollection<Estudiante> estudiantes { get; set; } = new List<Estudiante>();

    }
}
