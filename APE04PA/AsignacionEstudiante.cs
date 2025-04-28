using EstructuraEntidad;
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
    public partial class AsignacionEstudiante : Form
    {
        public AsignacionEstudiante()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cedulas c = new Cedulas();
            c.Show();
        }

        string idProfesor;
        List<EstudinteMateria> estudiantesCargados = new List<EstudinteMateria>();


        private void buttonCargarEstudintePorCedulaDeProfesor_Click(object sender, EventArgs e)
        {
            idProfesor = textBoxIdProfesor.Text;
            if (string.IsNullOrEmpty(idProfesor))
            {
                MessageBox.Show("Por favor, ingrese el ID del profesor.");
                return;
            }

            // Limpiamos antes de volver a cargar
            comboBoxElegirEstudiante.Items.Clear();
            labelCarrera.Text = "";

            estudiantesCargados = EstructuraDatos.EstudianteDatos.ObtenerEstudiantesConMateriasPorProfesor(idProfesor);

            if (estudiantesCargados.Count == 0)
            {
                MessageBox.Show("No se encontraron estudiantes para este profesor.");
            }
            else
            {
                foreach (var estudiante in estudiantesCargados)
                {
                    comboBoxElegirEstudiante.Items.Add(estudiante);  // Agregamos el objeto EstudianteMateria
                }
            }

        }

        private void comboBoxElegirEstudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxElegirEstudiante.SelectedItem is EstudinteMateria seleccionado)
            {
                labelCarrera.Text = seleccionado.NombreMateria;
            }

            if (comboBoxElegirEstudiante.SelectedItem is EstudinteMateria seleccionar)
            {
                Estudiante estudiante = EstructuraDatos.EstudianteDatos.ObtenerEstudiantePorCedula(seleccionar.IdCedulaEstudiante);

                if (estudiante != null)
                {
                    // Actualizar los labels con los datos del estudiante
                    labelNombre.Text = estudiante.NombreE;
                    labelApellido.Text = estudiante.ApellidoE;
                    labelTelefono.Text = estudiante.Telefono;
                    labelUsuario.Text = estudiante.UsuarioE;
                    labelCorreo.Text = estudiante.Correo;
                }
                else
                {
                    MessageBox.Show("No se encontraron los datos del estudiante.");
                }
            }
        }


        string notas;
        private void buttonCalcularNota_Click(object sender, EventArgs e)
        {
            
            List<TextBox> cajasNotas = new List<TextBox> { textBoxNota1, textBoxNota2, textBoxNota3, textBoxNota4 };
            List<double> listaNotas = new List<double>();
            List<string> notasComoTexto = new List<string>();

            foreach (TextBox caja in cajasNotas)
            {
                string texto = caja.Text.Trim();

                if (double.TryParse(texto, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double nota))
                {
                    if (nota >= 0 && nota <= 10)
                    {
                        listaNotas.Add(nota);
                        notasComoTexto.Add(nota.ToString(System.Globalization.CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        MessageBox.Show($"La nota '{nota}' no está en el rango permitido (0-10).", "Nota inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show($"El valor '{texto}' no es una nota válida.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (listaNotas.Count == 4)
            {
                double promedio = listaNotas.Average();
                labelPromedio.Text = promedio.ToString("0.00");

                if (promedio >= 7.0)
                {
                    labelAprueba.Text = "Aprueba";
                    labelAprueba.BackColor = Color.LightGreen;
                    labelAprueba.ForeColor = Color.Black;
                }
                else
                {
                    labelAprueba.Text = "No aprueba";
                    labelAprueba.BackColor = Color.LightCoral;
                    labelAprueba.ForeColor = Color.White;
                }

                // Guardamos SOLO las notas separadas por espacio
                notas = string.Join(" ", notasComoTexto);
            }
            else
            {
                MessageBox.Show("Debe ingresar las 4 notas válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonGuardarNotas_Click(object sender, EventArgs e)
        {
            if (comboBoxElegirEstudiante.SelectedItem is EstudinteMateria estudianteSeleccionado)
            {
                decimal promedioDecimal;
                if (!decimal.TryParse(labelPromedio.Text, out promedioDecimal))
                {
                    MessageBox.Show("Promedio inválido. Primero calcule las notas correctamente.");
                    return;
                }

                bool guardado = EstructuraDatos.CalificacionDatos.GuardarCalificacion(
                    estudianteSeleccionado.IdCedulaEstudiante,
                    estudianteSeleccionado.NombreMateria,
                    notas,
                    promedioDecimal,
                    labelAprueba.Text
                );

                if (guardado)
                {
                    MessageBox.Show("Calificación guardada exitosamente.");
                    comboBoxElegirEstudiante.SelectedIndex = -1;  // Desmarca cualquier selección
                    comboBoxElegirEstudiante.Items.Clear();  // Elimina todos los elementos
                    labelCarrera.Text= ".........";
                    labelNombre.Text = "----------";
                    labelApellido.Text = "----------";
                    labelCorreo.Text = "----------";
                    labelTelefono.Text = "----------";
                    labelUsuario.Text = "----------";
                    textBoxNota1.Text = "";
                    textBoxNota2.Text = "";
                    textBoxNota3.Text = "";
                    textBoxNota4.Text = "";
                    labelPromedio.Text = "...";
                    labelAprueba.Text = "...";

                }
                else
                {
                    MessageBox.Show("Error al guardar la calificación.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un estudiante.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonVerEstudiantesConCalificaciones_Click(object sender, EventArgs e)
        {
            string idProfesor = textBoxIdProfesor.Text.Trim();

            if (string.IsNullOrEmpty(idProfesor))
            {
                MessageBox.Show("Debe ingresar el ID del profesor antes de ver las calificaciones.");
                return;
            }
            else
            {
                comboBoxElegirEstudiante.SelectedIndex = -1;  // Desmarca cualquier selección
                comboBoxElegirEstudiante.Items.Clear();  // Elimina todos los elementos
                labelCarrera.Text = ".........";
                labelNombre.Text = "----------";
                labelApellido.Text = "----------";
                labelCorreo.Text = "----------";
                labelTelefono.Text = "----------";
                labelUsuario.Text = "----------";
                textBoxNota1.Text = "";
                textBoxNota2.Text = "";
                textBoxNota3.Text = "";
                textBoxNota4.Text = "";
                labelPromedio.Text = "...";
                labelAprueba.Text = "...";
                VerEstudiantesConCalificaciones m = new VerEstudiantesConCalificaciones(idProfesor);
                m.Show();
            }

                
        }
    }
}
