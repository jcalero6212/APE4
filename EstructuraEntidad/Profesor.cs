using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraEntidad
{
    public class Profesor
    {
        public string IdCedulaProfesor { get; set; }
        public string NombreP { get; set; }
        public string ApellidoP { get; set; }
        public DateTime FechaNacimientoP { get; set; }
        public string DireccionP { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string UsuarioP { get; set; }
        public string ContraseniaP { get; set; }
        public string IdCarreraProfesor { get; set; }

        public Profesor(string idCedulaProfesor, string nombreP, string apellidoP, DateTime fechaNacimientoP,
                        string direccionP, string correo, string telefono, string usuarioP, string contraseniaP,
                        string idCarreraProfesor)
        {
            IdCedulaProfesor = idCedulaProfesor;
            NombreP = nombreP;
            ApellidoP = apellidoP;
            FechaNacimientoP = fechaNacimientoP;
            DireccionP = direccionP;
            Correo = correo;
            Telefono = telefono;
            UsuarioP = usuarioP;
            ContraseniaP = contraseniaP;
            IdCarreraProfesor = idCarreraProfesor;
        }
    }
}
