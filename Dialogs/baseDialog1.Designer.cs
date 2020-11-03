namespace ClasesVirtualesProgramacion.Dialogs
{
    partial class baseDialog1
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
            this.btn1Guardar = new System.Windows.Forms.Button();
            this.btnCancelar1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn1Guardar
            // 
            this.btn1Guardar.Location = new System.Drawing.Point(85, 211);
            this.btn1Guardar.Name = "btn1Guardar";
            this.btn1Guardar.Size = new System.Drawing.Size(75, 23);
            this.btn1Guardar.TabIndex = 0;
            this.btn1Guardar.Text = "Guardar";
            this.btn1Guardar.UseVisualStyleBackColor = true;
            this.btn1Guardar.Click += new System.EventHandler(this.btn1Guardar_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar1.Location = new System.Drawing.Point(177, 211);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar1.TabIndex = 1;
            this.btnCancelar1.Text = "Cancelar";
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // baseDialog1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar1;
            this.ClientSize = new System.Drawing.Size(330, 296);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btn1Guardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "baseDialog1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "baseDialog1";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btn1Guardar;
        protected System.Windows.Forms.Button btnCancelar1;
    }
}