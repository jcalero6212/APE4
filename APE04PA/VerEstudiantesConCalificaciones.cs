using EstructuraDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APE04PA
{
    public partial class VerEstudiantesConCalificaciones : Form
    {
        string IdProfe;
        public VerEstudiantesConCalificaciones(string idProfe)
        {
            InitializeComponent();
            IdProfe = idProfe;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Extrae los datos necesarios
                string idEstudiante = row.Cells["IdEstudiante"].Value.ToString();
                string materia = row.Cells["Materia"].Value.ToString();
                string idProfesor = IdProfe; // Ya lo tienes guardado desde el formulario

                string idCalificacion = row.Cells["idCalificacion"].Value.ToString(); 

                // Actualizar otros labels
                labelEstudianteId.Text = idEstudiante;
                labelMateria.Text = materia;
                labelidCalificacion.Text = idCalificacion;
            }
        }

        

        public string DevolverProfe(string idProfe)
        {
            return IdProfe = idProfe;
        }
        private void VerEstudiantesConCalificaciones_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IdProfe))
            {
                MessageBox.Show("ID del profesor no recibido.");
                return;
            }

            if (!EstructuraDatos.ProfesorDatos.ExisteProfesor(IdProfe))
            {
                MessageBox.Show("El profesor no existe.");
                return;
            }

            var calificaciones = EstructuraDatos.CalificacionDatos.ObtenerCalificacionesPorProfesor(IdProfe);

            if (calificaciones.Count == 0)
            {
                MessageBox.Show("No se encontraron calificaciones para este profesor.");
                return;
            }

            dataGridView1.DataSource = calificaciones;
        }

       
        public string ObtenerIdProfesor() => IdProfe;

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (labelidCalificacion.Text != ".........." && !string.IsNullOrEmpty(labelidCalificacion.Text))
            {
                // Confirmación antes de eliminar
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar esta calificación?",
                                                            "Confirmar eliminación",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        // Convertir el contenido del label a un entero (idCalificacion)
                        int idCalificacion = Convert.ToInt32(labelidCalificacion.Text);

                        // Llamar al método de eliminación
                        bool eliminado =  EstructuraDatos.CalificacionDatos.EliminarCalificacion(idCalificacion);

                        if (eliminado)
                        {
                            MessageBox.Show("La calificación ha sido eliminada correctamente.");
                            // Limpiar el label después de la eliminación
                            labelidCalificacion.Text = "..........";
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la calificación.");
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("El ID de la calificación no es válido.");
                    }
                }
                else
                {
                    // Si el usuario seleccionó "No", no hacemos nada
                    MessageBox.Show("La eliminación ha sido cancelada.");
                }
            }
            else
            {
                // Si el label no tiene un ID válido
                MessageBox.Show("No hay calificación seleccionada para eliminar.");
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelidCalificacion.Text) || labelidCalificacion.Text == "..........")
            {
                MessageBox.Show("Por favor, seleccione una calificación válida para editar.");
                return; // No hacer nada si la validación falla
            }

            // Si la validación pasa, abrir el formulario de edición
            EditarCalificacion m = new EditarCalificacion(labelidCalificacion.Text);
            m.Show();
            this.Close();
        }
    }

}

