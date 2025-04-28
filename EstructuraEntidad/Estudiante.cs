using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraEntidad
{
    public class Estudiante
    {
        public string IdCedulaEstudiante { get; set; }
        public string NombreE { get; set; }
        public string ApellidoE { get; set; }
        public DateTime FechaNacimientoE { get; set; }
        public string DireccionE { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string UsuarioE { get; set; }
        public string ContraseniaE { get; set; }

        public string NombreMateria { get; set; }


        // Constructor
        public Estudiante(string idCedulaEstudiante, string nombreE, string apellidoE, DateTime fechaNacimientoE,
                          string direccionE, string correo, string telefono, string usuarioE, string contraseniaE)
        {
            IdCedulaEstudiante = idCedulaEstudiante;
            NombreE = nombreE;
            ApellidoE = apellidoE;
            FechaNacimientoE = fechaNacimientoE;
            DireccionE = direccionE;
            Correo = correo;
            Telefono = telefono;
            UsuarioE = usuarioE;
            ContraseniaE = contraseniaE;
        }

        public Estudiante()
        {
           
        }
    }
}
