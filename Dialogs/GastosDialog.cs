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
    public partial class GastosDialog : baseDialog1
    {
        public GastosDialog()
        {
            InitializeComponent();
        }
        protected override bool ValidarEntrada()

        {
            erp.Clear();
            if (valorTextBox.Text.Trim() == string.Empty)
                return NotificacionDeValidacion("Por favor escriba el precio para el Producto dado.", valorTextBox);

            if (formapagoComboBox.SelectedIndex < 0)
                return NotificacionDeValidacion("Por favor seleccione una forma de pago.", formapagoComboBox);

            if (categoriaComboBox.SelectedIndex < 0)
                return NotificacionDeValidacion("Por favor seleccione el producto .", categoriaComboBox);

            if (subcategoriaComboBox.SelectedIndex < 0)
                return NotificacionDeValidacion("Por favor seleccione el producto de supermercado.", subcategoriaComboBox);

            if (descripcionTextBox.Text.Trim()==string.Empty)
                return NotificacionDeValidacion("Por favor ingrese la cantidad de producto .", descripcionTextBox);

            return true;
        }



        private void fechaLabel_Click(object sender, EventArgs e)
        {

        }

        private void GastosDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
