using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EstructuraEntidad;
using EstructuraDatos;

namespace APE04PA
{
    public partial class Cedulas : Form
    {
        public Cedulas()
        {
            InitializeComponent();
        }

        private void Cedulas_Load(object sender, EventArgs e)
        {
            List<Profesor> listaProfesores = EstructuraDatos.ProfesorDatos.ObtenerProfesores(); // Llamas a tu método
            dataGridView1.DataSource = listaProfesores;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
