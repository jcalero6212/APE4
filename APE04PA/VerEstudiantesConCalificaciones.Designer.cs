namespace APE04PA
{
    partial class VerEstudiantesConCalificaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEstudianteId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelidCalificacion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMateria = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1043, 301);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(396, 506);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(94, 34);
            this.buttonEditar.TabIndex = 1;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(561, 506);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(81, 34);
            this.buttonEliminar.TabIndex = 2;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Calificaciones:";
            // 
            // labelEstudianteId
            // 
            this.labelEstudianteId.AutoSize = true;
            this.labelEstudianteId.Location = new System.Drawing.Point(216, 460);
            this.labelEstudianteId.Name = "labelEstudianteId";
            this.labelEstudianteId.Size = new System.Drawing.Size(45, 20);
            this.labelEstudianteId.TabIndex = 4;
            this.labelEstudianteId.Text = ".........";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cedula Estudiante:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "id Calificacion:";
            // 
            // labelidCalificacion
            // 
            this.labelidCalificacion.AutoSize = true;
            this.labelidCalificacion.Location = new System.Drawing.Point(428, 460);
            this.labelidCalificacion.Name = "labelidCalificacion";
            this.labelidCalificacion.Size = new System.Drawing.Size(49, 20);
            this.labelidCalificacion.TabIndex = 7;
            this.labelidCalificacion.Text = "..........";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(631, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Materia:";
            // 
            // labelMateria
            // 
            this.labelMateria.AutoSize = true;
            this.labelMateria.Location = new System.Drawing.Point(631, 460);
            this.labelMateria.Name = "labelMateria";
            this.labelMateria.Size = new System.Drawing.Size(49, 20);
            this.labelMateria.TabIndex = 9;
            this.labelMateria.Text = "..........";
            // 
            // VerEstudiantesConCalificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::APE04PA.Properties.Resources.imagenSoporte;
            this.ClientSize = new System.Drawing.Size(1118, 576);
            this.Controls.Add(this.labelMateria);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelidCalificacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelEstudianteId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "VerEstudiantesConCalificaciones";
            this.Text = "VerEstudiantesConCalificaciones";
            this.Load += new System.EventHandler(this.VerEstudiantesConCalificaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEstudianteId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelidCalificacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelMateria;
    }
}