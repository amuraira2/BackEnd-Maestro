using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Caseta", Schema = "catalogos")]
    public class Caseta
    {
        [Key]
        [Column("CasetaId")]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Nombre { get; set; }
        [MaxLength(250)]
        public DateTime FechaAlta { get; set; }
        [MaxLength(15)]
        public DateTime FechaEdita { get; set; }
        [MaxLength(15)]
        public DateTime FechaElimina { get; set; }
        [MaxLength(15)]
        public string Rfc { get; set; }
        [MaxLength(15)]
        public bool BActivo { get; set; }

        public ICollection<Caseta> Casetas { get; set; }
    }
}