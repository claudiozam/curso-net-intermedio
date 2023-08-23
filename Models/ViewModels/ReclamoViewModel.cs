using System.ComponentModel.DataAnnotations;

namespace WebApplicationSistemaReclamosV2.Models.ViewModels
{
    public class ReclamoViewModel
    {

        private long id;
        private string titulo;
        private string descripcion;
        private DateTime fechaAlta;
        private string estado = "nuevo";

        public ReclamoViewModel() { }

        public ReclamoViewModel(long id, string titulo, string descripcion, DateTime fechaAlta, string estado)
        {
            this.id = id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fechaAlta = fechaAlta;
            this.estado = estado;
        }

        [Display(Name = "ID")]
        public long Id { get => id; set => id = value; }

        [Required(ErrorMessage = "Falta completar el titulo")]
        [StringLength(50)]
        [Display(Name = "Titulo")]
        public string Titulo { get => titulo; set => titulo = value; }

        [Required(ErrorMessage = "Falta completar la descripcion")]
        [Display(Name = "Descripcion completa del reclamo")]
        public string Descripcion { get => descripcion; set => descripcion = value; }

        [Display(Name = "Fecha de alta")]
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }

        [Display(Name = "Estado actual")]
        public string Estado { get => estado; set => estado = value; }
    }
}
