using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasesVirtualesProgramacion.Dialogs;

namespace ClasesVirtualesProgramacion.Dialogs
{
    public partial class EstudianteDialog : baseDialog
    {
        public EstudianteDialog()
        {
            InitializeComponent();
        }

        protected override bool ValidarEntrada()
        {
            erp.Clear();
            if (identidadTextBox.Text.Trim()==string.Empty)
                return NotificacionDeValidacion("Por favor escriba el numero de identidad del estudiante", identidadTextBox);
            if (sexoComboBox.SelectedIndex < 0)
                return NotificacionDeValidacion("POr favor seleccione masculino o femenino para sexo del estudiante", sexoComboBox);

            if (nombresTextBox.Text.Trim() == string.Empty)
                return NotificacionDeValidacion("Por favor escriba los nombres completos del estudiante", nombresTextBox);

            if (apellidosTextBox.Text.Trim() == string.Empty)
                return NotificacionDeValidacion("Por favor escriva los apellidos completos del estudiante", apellidosTextBox);

                if (direccionTextBox.Text.Trim() == string.Empty)
                return NotificacionDeValidacion("Por favor escriva la direccion donde el estudiante vive", direccionTextBox);
                
            return true;
        }


        private void estudiantesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void estudiantesBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void EstudianteDialog_Load(object sender, EventArgs e)
        {

        }

        private void obsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void direccionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void apellidosTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombresTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
