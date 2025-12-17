namespace WinAppCurvas
{
    partial class CurvasB
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.lblTValue = new System.Windows.Forms.Label();
            this.chkVerLineas = new System.Windows.Forms.CheckBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAnimar = new System.Windows.Forms.Button();
            this.cmbTipoCurva = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.pbLienzo = new System.Windows.Forms.PictureBox();
            this.tmrAnimacion = new System.Windows.Forms.Timer(this.components);
            this.pnlControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLienzo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControles
            // 
            this.pnlControles.BackColor = System.Drawing.Color.Thistle;
            this.pnlControles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControles.Controls.Add(this.lblInstrucciones);
            this.pnlControles.Controls.Add(this.lblTValue);
            this.pnlControles.Controls.Add(this.chkVerLineas);
            this.pnlControles.Controls.Add(this.btnLimpiar);
            this.pnlControles.Controls.Add(this.btnAnimar);
            this.pnlControles.Controls.Add(this.cmbTipoCurva);
            this.pnlControles.Controls.Add(this.lblTipo);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControles.Location = new System.Drawing.Point(0, 0);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(220, 611);
            this.pnlControles.TabIndex = 0;
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstrucciones.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblInstrucciones.Location = new System.Drawing.Point(10, 520);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(200, 50);
            this.lblInstrucciones.TabIndex = 7;
            this.lblInstrucciones.Text = "**Interacción:**\r\nClic Izq: Agregar/Mover\r\nClic Der: Eliminar último";
            // 
            // lblTValue
            // 
            this.lblTValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTValue.Location = new System.Drawing.Point(10, 577);
            this.lblTValue.Name = "lblTValue";
            this.lblTValue.Size = new System.Drawing.Size(200, 25);
            this.lblTValue.TabIndex = 6;
            this.lblTValue.Text = "t = 1.00";
            this.lblTValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkVerLineas
            // 
            this.chkVerLineas.AutoSize = true;
            this.chkVerLineas.Checked = true;
            this.chkVerLineas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerLineas.Location = new System.Drawing.Point(15, 180);
            this.chkVerLineas.Name = "chkVerLineas";
            this.chkVerLineas.Size = new System.Drawing.Size(78, 17);
            this.chkVerLineas.TabIndex = 4;
            this.chkVerLineas.Text = "Ver Líneas";
            this.chkVerLineas.UseVisualStyleBackColor = true;
            this.chkVerLineas.CheckedChanged += new System.EventHandler(this.chkVerLineas_CheckedChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(15, 130);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(195, 30);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAnimar
            // 
            this.btnAnimar.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnAnimar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnimar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnimar.ForeColor = System.Drawing.Color.White;
            this.btnAnimar.Location = new System.Drawing.Point(15, 90);
            this.btnAnimar.Name = "btnAnimar";
            this.btnAnimar.Size = new System.Drawing.Size(195, 30);
            this.btnAnimar.TabIndex = 3;
            this.btnAnimar.Text = "Iniciar";
            this.btnAnimar.UseVisualStyleBackColor = false;
            this.btnAnimar.Click += new System.EventHandler(this.btnAnimar_Click);
            // 
            // cmbTipoCurva
            // 
            this.cmbTipoCurva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCurva.FormattingEnabled = true;
            this.cmbTipoCurva.Items.AddRange(new object[] {
            "Bézier - Lineal (Grado 1)",
            "Bézier - Cuadrática (Grado 2)",
            "Bézier - Cúbica (Grado 3)",
            "Bézier - N Grados",
            "B-Spline (Cúbica Uniforme)"});
            this.cmbTipoCurva.Location = new System.Drawing.Point(15, 50);
            this.cmbTipoCurva.Name = "cmbTipoCurva";
            this.cmbTipoCurva.Size = new System.Drawing.Size(195, 21);
            this.cmbTipoCurva.TabIndex = 1;
            this.cmbTipoCurva.SelectedIndexChanged += new System.EventHandler(this.cmbTipoCurva_SelectedIndexChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(12, 20);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(77, 16);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Algoritmo:";
            // 
            // pbLienzo
            // 
            this.pbLienzo.BackColor = System.Drawing.Color.White;
            this.pbLienzo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLienzo.Location = new System.Drawing.Point(220, 0);
            this.pbLienzo.Name = "pbLienzo";
            this.pbLienzo.Size = new System.Drawing.Size(764, 611);
            this.pbLienzo.TabIndex = 1;
            this.pbLienzo.TabStop = false;
            this.pbLienzo.Click += new System.EventHandler(this.pbLienzo_Click);
            this.pbLienzo.Paint += new System.Windows.Forms.PaintEventHandler(this.pbLienzo_Paint);
            this.pbLienzo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbLienzo_MouseDown);
            this.pbLienzo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbLienzo_MouseMove);
            this.pbLienzo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbLienzo_MouseUp);
            // 
            // tmrAnimacion
            // 
            this.tmrAnimacion.Interval = 20;
            this.tmrAnimacion.Tick += new System.EventHandler(this.tmrAnimacion_Tick);
            // 
            // CurvasB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.pbLienzo);
            this.Controls.Add(this.pnlControles);
            this.Name = "CurvasB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computación Gráfica: Curvas Bézier y B-Spline Interactivas (Diseño Vertical)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLienzo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.PictureBox pbLienzo;
        private System.Windows.Forms.ComboBox cmbTipoCurva;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Button btnAnimar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.CheckBox chkVerLineas;
        private System.Windows.Forms.Timer tmrAnimacion;
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.Label lblTValue;
    }
}