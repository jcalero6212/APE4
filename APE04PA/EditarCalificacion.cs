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
    public partial class EditarCalificacion : Form
    {
        int idcalificaciones;
        public EditarCalificacion(string idcalificacion)
        {
            InitializeComponent();
            idcalificaciones = Int32.Parse(idcalificacion);
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
            if (ValidarCampos())
            {
                EstructuraDatos.CalificacionDatos.ModificarCalificacion(idcalificaciones, notas, Convert.ToDecimal(labelPromedio.Text), labelAprueba.Text);
                this.Close();
            }
            

        }

        private bool ValidarCampos()
        {
            // Verificar si las notas no son nulas y tienen valores válidos
            if (string.IsNullOrEmpty(textBoxNota1.Text) || string.IsNullOrEmpty(textBoxNota2.Text) ||
                string.IsNullOrEmpty(textBoxNota3.Text) || string.IsNullOrEmpty(textBoxNota4.Text))
            {
                MessageBox.Show("Por favor, ingrese todas las notas.");
                return false;
            }

            // Verificar si el label de aprobación tiene un valor válido
            if (labelAprueba.Text == "....")
            {
                MessageBox.Show("El estado de aprobación no ha sido determinado.");
                return false;
            }

            // Verificar si el label de promedio tiene un valor válido
            if (labelPromedio.Text == "...")
            {
                MessageBox.Show("El promedio no ha sido calculado.");
                return false;
            }

            return true; // Si todo está correcto, retorna true
        }

        private void EditarCalificacion_Load(object sender, EventArgs e)
        {
            string[] notas = SepararNotas (CalificacionDatos.ObtenerNotasPorIdCalificacion(idcalificaciones));
            textBoxNota1.Text = notas[0];
            textBoxNota2.Text = notas[1];
            textBoxNota3 .Text = notas[2];
            textBoxNota4 .Text = notas[3];
        }

        public static string[] SepararNotas(string notas)
        {
            string[] arregloNotas = new string[4];  // Arreglo para las 4 calificaciones

            if (!string.IsNullOrEmpty(notas))
            {
                // Separamos las notas por espacio
                string[] partes = notas.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (partes.Length == 4)
                {
                    // Si tenemos exactamente 4 partes, las agregamos al arreglo
                    for (int i = 0; i < 4; i++)
                    {
                        if (double.TryParse(partes[i], out double resultado))
                        {
                            // Si la parte es un número válido, la agregamos al arreglo
                            arregloNotas[i] = partes[i];
                        }
                        else
                        {
                            // Si no es un número válido, podrías devolver un error o manejarlo
                            Console.WriteLine($"Nota no válida: {partes[i]}");
                            arregloNotas[i] = "0"; // O cualquier valor predeterminado, según lo que prefieras
                        }
                    }
                }
                else
                {
                    // Si no tenemos exactamente 4 notas, mostramos un mensaje de error
                    Console.WriteLine("Debe ingresar exactamente 4 notas.");
                }
            }

            return arregloNotas;
        }
    }
}
