using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos
{


    public static class CalificacionDatos
    {
        
        public static List<dynamic> ObtenerCalificacionesPorProfesor(string idCedulaProfesor)
        {
            List<dynamic> calificaciones = new List<dynamic>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    string consulta = @"
                SELECT 
                    E.idCedulaEstudiante, 
                    MT.nombreM AS Materia,
                    C.idCalificaciones,
                    C.idMatricula, 
                    C.notas, 
                    C.promedio, 
                    C.descripcion
                FROM Calificaciones C
                JOIN Matricula M ON C.idMatricula = M.idMatricula
                JOIN Estudiante E ON M.idCedulaEstudiante = E.idCedulaEstudiante
                JOIN Materia MT ON M.idMateria = MT.idMateria
                WHERE MT.idCedulaProfesor = @idCedulaProfesor";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idCedulaProfesor", idCedulaProfesor);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                calificaciones.Add(new
                                {
                                    IdCalificacion = reader["idCalificaciones"],
                                    IdEstudiante = reader["idCedulaEstudiante"].ToString(),
                                    Materia = reader["Materia"].ToString(),
                                    IdMatricula = Convert.ToInt32(reader["idMatricula"]),
                                    Notas = reader["notas"].ToString(),
                                    Promedio = Convert.ToDecimal(reader["promedio"]),
                                    Descripcion = reader["descripcion"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener calificaciones: " + ex.Message);
            }

            return calificaciones;
        }


        // Método para guardar la calificación
        public static bool GuardarCalificacion(string idCedulaEstudiante, string nombreMateria, string notas, decimal promedio, string descripcion)
        {
            bool guardadoCorrectamente = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    // Primero obtenemos el idMatricula
                    string consultaMatricula = @"
                        SELECT M.idMatricula
                        FROM Matricula M
                        JOIN Materia MT ON M.idMateria = MT.idMateria
                        WHERE M.idCedulaEstudiante = @idCedulaEstudiante
                        AND MT.nombreM = @nombreMateria";

                    int idMatricula = -1;
                    using (SqlCommand cmdMatricula = new SqlCommand(consultaMatricula, conexion))
                    {
                        cmdMatricula.Parameters.AddWithValue("@idCedulaEstudiante", idCedulaEstudiante);
                        cmdMatricula.Parameters.AddWithValue("@nombreMateria", nombreMateria);

                        object resultado = cmdMatricula.ExecuteScalar();
                        if (resultado != null)
                        {
                            idMatricula = Convert.ToInt32(resultado);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró la matrícula.");
                            return false;
                        }
                    }

                    // Insertamos la nueva calificación
                    string consultaInsert = @"
                        INSERT INTO Calificaciones (idMatricula, notas, promedio, descripcion)
                        VALUES (@idMatricula, @notas, @promedio, @descripcion)";

                    using (SqlCommand cmdInsert = new SqlCommand(consultaInsert, conexion))
                    {
                        cmdInsert.Parameters.AddWithValue("@idMatricula", idMatricula);
                        cmdInsert.Parameters.AddWithValue("@notas", notas);
                        cmdInsert.Parameters.AddWithValue("@promedio", promedio);
                        cmdInsert.Parameters.AddWithValue("@descripcion", descripcion);

                        int filasAfectadas = cmdInsert.ExecuteNonQuery();
                        guardadoCorrectamente = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar calificación: " + ex.Message);
            }

            return guardadoCorrectamente;
        }


        //Eliminar calificacion 
        public static bool EliminarCalificacion(int idCalificacion)
        {
            bool eliminadoCorrectamente = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    // Consulta SQL para eliminar la calificación por idCalificacion
                    string consultaEliminar = @"
                DELETE FROM Calificaciones
                WHERE idCalificaciones = @idCalificacion";

                    using (SqlCommand cmdEliminar = new SqlCommand(consultaEliminar, conexion))
                    {
                        // Agregamos el parámetro para el idCalificacion
                        cmdEliminar.Parameters.AddWithValue("@idCalificacion", idCalificacion);

                        // Ejecutamos la consulta y verificamos si se eliminó correctamente
                        int filasAfectadas = cmdEliminar.ExecuteNonQuery();
                        eliminadoCorrectamente = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la calificación: " + ex.Message);
            }

            return eliminadoCorrectamente;
        }

        //modificar calificacion
        public static bool ModificarCalificacion(int idCalificacion, string nuevasNotas, decimal nuevoPromedio, string nuevaDescripcion)
        {
            bool modificacionExitosa = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    // Consulta para actualizar las notas, promedio y descripción de la calificación según el idCalificacion
                    string consultaActualizar = @"
                UPDATE Calificaciones
                SET notas = @nuevasNotas,
                    promedio = @nuevoPromedio,
                    descripcion = @nuevaDescripcion
                WHERE idCalificaciones = @idCalificacion";

                    using (SqlCommand cmdActualizar = new SqlCommand(consultaActualizar, conexion))
                    {
                        cmdActualizar.Parameters.AddWithValue("@nuevasNotas", nuevasNotas);
                        cmdActualizar.Parameters.AddWithValue("@nuevoPromedio", nuevoPromedio);
                        cmdActualizar.Parameters.AddWithValue("@nuevaDescripcion", nuevaDescripcion);
                        cmdActualizar.Parameters.AddWithValue("@idCalificacion", idCalificacion);

                        int filasAfectadas = cmdActualizar.ExecuteNonQuery();
                        modificacionExitosa = filasAfectadas > 0; // Si se modificaron filas, la operación fue exitosa
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar la calificación: " + ex.Message);
            }

            return modificacionExitosa;
        }

        public static string ObtenerNotasPorIdCalificacion(int idCalificacion)
        {
            string notas = "";  // Inicializamos la variable que almacenará las notas

            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    string consulta = @"
                SELECT notas
                FROM Calificaciones
                WHERE idCalificaciones = @idCalificacion";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idCalificacion", idCalificacion);

                        object resultado = cmd.ExecuteScalar();  // Ejecutar la consulta y obtener el primer valor de la columna notas

                        if (resultado != null)
                        {
                            notas = resultado.ToString();  // Convertimos el resultado a un string
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ninguna calificación con ese ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener las notas: " + ex.Message);
            }

            return notas; 
        }
    }
}
