using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstructuraEntidad;

namespace EstructuraDatos
{
    public static class EstudianteDatos
    {

        public static Estudiante ObtenerEstudiantePorCedula(string idCedulaEstudiante)
        {
            Estudiante estudiante = null;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM Estudiante WHERE idCedulaEstudiante = @idCedulaEstudiante";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idCedulaEstudiante", idCedulaEstudiante);

                        using (SqlDataReader leer = cmd.ExecuteReader())
                        {
                            if (leer.Read())
                            {
                                estudiante = new Estudiante(
                                    leer["idCedulaEstudiante"].ToString(),
                                    leer["nombreE"].ToString(),
                                    leer["apellidoE"].ToString(),
                                    Convert.ToDateTime(leer["fechaNacimientoE"]),
                                    leer["direccionE"].ToString(),
                                    leer["correo"].ToString(),
                                    leer["telefono"].ToString(),
                                    leer["usuarioE"].ToString(),
                                    leer["contraseniaE"] == DBNull.Value ? null : leer["contraseniaE"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error al obtener estudiantes con materias");
            }

            return estudiante;
        }

        public static List<EstudinteMateria> ObtenerEstudiantesConMateriasPorProfesor(string idCedulaProfesor)
        {
            List<EstudinteMateria> estudiantes = new List<EstudinteMateria>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    string consulta = @"SELECT E.idCedulaEstudiante, MT.nombreM
                                FROM Estudiante E
                                JOIN Matricula M ON E.idCedulaEstudiante = M.idCedulaEstudiante
                                JOIN Materia MT ON M.idMateria = MT.idMateria
                                WHERE MT.idCedulaProfesor = @idProfesor
                                AND M.idMatricula NOT IN (SELECT idMatricula FROM Calificaciones)";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idProfesor", idCedulaProfesor);

                        SqlDataReader leer = cmd.ExecuteReader();
                        while (leer.Read())
                        {
                            EstudinteMateria estudianteMateria = new EstudinteMateria
                            {
                                IdCedulaEstudiante = leer["idCedulaEstudiante"].ToString(),
                                NombreMateria = leer["nombreM"].ToString()
                            };

                            estudiantes.Add(estudianteMateria);
                        }
                        leer.Close();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error al obtener estudiantes con materias");
            }

            return estudiantes;
        }
        public static List<Estudiante> ObtenerIdEstudiantePorProfesor(string idCedulaProfesor)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    string consulta = @"
                        SELECT E.idCedulaEstudiante, MT.nombreM
                        FROM Estudiante E
                        JOIN Matricula M ON E.idCedulaEstudiante = M.idCedulaEstudiante
                        JOIN Materia MT ON M.idMateria = MT.idMateria
                        WHERE MT.idCedulaProfesor = @idCedulaProfesor
                        AND M.idMatricula NOT IN (SELECT idMatricula FROM Calificaciones)";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idCedulaProfesor", idCedulaProfesor);

                        SqlDataReader leer = cmd.ExecuteReader();
                        while (leer.Read())
                        {
                            Estudiante estudiante = new Estudiante
                            {
                                IdCedulaEstudiante = leer["idCedulaEstudiante"].ToString(),
                                NombreMateria = leer["nombreM"].ToString()
                            };

                            estudiantes.Add(estudiante);
                        }
                        leer.Close();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error al obtener estudiantes por profesor.");
            }

            return estudiantes;
        }
    }
}
