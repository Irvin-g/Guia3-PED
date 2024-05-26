
namespace Guia3
{
    partial class Form1
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
            this.panelDibujo = new System.Windows.Forms.Panel();
            this.btnAgregarNodo = new System.Windows.Forms.Button();
            this.btnAgregarArco = new System.Windows.Forms.Button();
            this.btnEjecutarDijkstra = new System.Windows.Forms.Button();
            this.txtNodoInicial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstResultados = new System.Windows.Forms.ListBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblRutaCorta = new System.Windows.Forms.Label();
            this.btnCalcularRuta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelDibujo
            // 
            this.panelDibujo.Location = new System.Drawing.Point(366, 22);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(362, 383);
            this.panelDibujo.TabIndex = 0;
            // 
            // btnAgregarNodo
            // 
            this.btnAgregarNodo.Location = new System.Drawing.Point(16, 69);
            this.btnAgregarNodo.Name = "btnAgregarNodo";
            this.btnAgregarNodo.Size = new System.Drawing.Size(97, 31);
            this.btnAgregarNodo.TabIndex = 1;
            this.btnAgregarNodo.Text = "Agregar nodos";
            this.btnAgregarNodo.UseVisualStyleBackColor = true;
            // 
            // btnAgregarArco
            // 
            this.btnAgregarArco.Location = new System.Drawing.Point(134, 69);
            this.btnAgregarArco.Name = "btnAgregarArco";
            this.btnAgregarArco.Size = new System.Drawing.Size(100, 31);
            this.btnAgregarArco.TabIndex = 2;
            this.btnAgregarArco.Text = "Agregar arcos";
            this.btnAgregarArco.UseVisualStyleBackColor = true;
            // 
            // btnEjecutarDijkstra
            // 
            this.btnEjecutarDijkstra.Location = new System.Drawing.Point(240, 150);
            this.btnEjecutarDijkstra.Name = "btnEjecutarDijkstra";
            this.btnEjecutarDijkstra.Size = new System.Drawing.Size(99, 25);
            this.btnEjecutarDijkstra.TabIndex = 3;
            this.btnEjecutarDijkstra.Text = "Ejecutar";
            this.btnEjecutarDijkstra.UseVisualStyleBackColor = true;
            // 
            // txtNodoInicial
            // 
            this.txtNodoInicial.Location = new System.Drawing.Point(134, 155);
            this.txtNodoInicial.Name = "txtNodoInicial";
            this.txtNodoInicial.Size = new System.Drawing.Size(100, 20);
            this.txtNodoInicial.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ingresar el nodo inicial:";
            // 
            // lstResultados
            // 
            this.lstResultados.FormattingEnabled = true;
            this.lstResultados.Location = new System.Drawing.Point(16, 184);
            this.lstResultados.Name = "lstResultados";
            this.lstResultados.Size = new System.Drawing.Size(218, 134);
            this.lstResultados.TabIndex = 6;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(240, 295);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(99, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblRutaCorta
            // 
            this.lblRutaCorta.AutoSize = true;
            this.lblRutaCorta.Location = new System.Drawing.Point(16, 348);
            this.lblRutaCorta.Name = "lblRutaCorta";
            this.lblRutaCorta.Size = new System.Drawing.Size(35, 13);
            this.lblRutaCorta.TabIndex = 8;
            this.lblRutaCorta.Text = "label2";
            // 
            // btnCalcularRuta
            // 
            this.btnCalcularRuta.Location = new System.Drawing.Point(240, 215);
            this.btnCalcularRuta.Name = "btnCalcularRuta";
            this.btnCalcularRuta.Size = new System.Drawing.Size(99, 23);
            this.btnCalcularRuta.TabIndex = 9;
            this.btnCalcularRuta.Text = "Calcular Ruta";
            this.btnCalcularRuta.UseVisualStyleBackColor = true;
            this.btnCalcularRuta.Click += new System.EventHandler(this.btnCalcularRuta_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(740, 417);
            this.Controls.Add(this.btnCalcularRuta);
            this.Controls.Add(this.lblRutaCorta);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lstResultados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNodoInicial);
            this.Controls.Add(this.btnEjecutarDijkstra);
            this.Controls.Add(this.btnAgregarArco);
            this.Controls.Add(this.btnAgregarNodo);
            this.Controls.Add(this.panelDibujo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.Button btnAgregarNodo;
        private System.Windows.Forms.Button btnAgregarArco;
        private System.Windows.Forms.Button btnEjecutarDijkstra;
        private System.Windows.Forms.TextBox txtNodoInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstResultados;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblRutaCorta;
        private System.Windows.Forms.Button btnCalcularRuta;
    }
}

