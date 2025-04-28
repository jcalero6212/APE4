using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstructuraEntidad;

namespace EstructuraDatos
{
    public static class ProfesorDatos
    {

        public static bool ExisteProfesor(string idCedulaProfesor)
        {
            bool existe = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();
                    string consulta = "SELECT COUNT(*) FROM Profesor WHERE idCedulaProfesor = @idCedulaProfesor";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idCedulaProfesor", idCedulaProfesor);
                        int count = (int)cmd.ExecuteScalar();
                        existe = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar profesor: " + ex.Message);
            }

            return existe;
        }

        public static List<Profesor> ObtenerProfesores()
        {
            List<Profesor> listaProfesores = new List<Profesor>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    string consulta = "SELECT * FROM Profesor";
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        SqlDataReader leer = cmd.ExecuteReader();
                        while (leer.Read())
                        {
                            Profesor profesor = new Profesor(
                                leer["idCedulaProfesor"].ToString(),
                                leer["nombreP"].ToString(),
                                leer["apellidoP"].ToString(),
                                Convert.ToDateTime(leer["fechaNacimientoP"]),
                                leer["direccionP"].ToString(),
                                leer["correo"].ToString(),
                                leer["telefono"].ToString(),
                                leer["usuarioP"].ToString(),
                                leer["contraseniaP"] == DBNull.Value ? null : leer["contraseniaP"].ToString(),
                                leer["idCarreraProfesor"].ToString()
                            );

                            listaProfesores.Add(profesor);
                        }
                        leer.Close();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error al obtener profesores");
            }

            return listaProfesores;
        }


    }
}
