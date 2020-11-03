using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClasesVirtualesProgramacion.Dialogs
{
    public partial class baseDialog1 : Form
    {
        protected ErrorProvider erp = new ErrorProvider();
        public baseDialog1()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        
            {
                Close();
            }

        protected virtual bool ValidarEntrada()
        {
            return true;
        }
        public bool NotificacionDeValidacion(string message, Control objeto)
        {
            MessageBox.Show(message, "Información no Ingresada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (objeto != null)
                objeto.Focus();
            erp.SetError(objeto, message);
            return false;
        }
    

        private void btn1Guardar_Click(object sender, EventArgs e)
            {
                if (ValidarEntrada() == false)
                    return;

                DialogResult = DialogResult.OK;
            }
    }
}
