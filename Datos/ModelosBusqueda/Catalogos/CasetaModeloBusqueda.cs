using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosBusqueda.Catalogos
{
    public class CasetaModeloBusqueda
    {
        public int Id { get; set; } = 0;
        public string Nombre { get; set; } = "";
        public DateTime FechaInicio { get; set; } = new DateTime(1, 1, 1);
        public DateTime FechaFin { get; set; } = new DateTime(1, 1, 1);
        public string Rfc { get; set; } = "";
    }
}
