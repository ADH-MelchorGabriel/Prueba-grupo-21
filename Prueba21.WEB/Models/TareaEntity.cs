using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba21.WEB.Models
{
    [Table("Tareas")]
    public class TareaEntity
    {
        [Key]public int Id { get; set; }
        [StringLength(30),Required]public string Tarea { get; set; } = "";
        [StringLength(200),Required]public string Descripcion { get; set; } = "";
        [Required]public bool Estatus { get; set; }

    }
}
