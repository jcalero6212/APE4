using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraEntidad
{
    public class EstudinteMateria
    {
        public string IdCedulaEstudiante { get; set; }
        public string NombreMateria { get; set; }

        public override string ToString()
        {
            return IdCedulaEstudiante;  // Solo mostramos la cédula en el ComboBox
        }
    }
}
