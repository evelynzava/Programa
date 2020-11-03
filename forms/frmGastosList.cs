using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClasesVirtualesProgramacion.Forms
{
    public partial class frmGastosList : Form
    {
        admGastos aConexion = new admGastos();
        public frmGastosList()
        {
            InitializeComponent();
        }

        private void gastosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmGastosList_Load(object sender, EventArgs e)
        {
            dslistadegastos.Gastos.Clear();
            string selectSQl = "Select * from gastos";
            if (aConexion.selectData(selectSQl, dslistadegastos.Gastos) != true)
                MessageBox.Show("No se ha podido cargar ningun dato de algun gasto, contacte el departamento de desarrollo tecnico", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            Dialogs.GastosDialog frmNuevo1 = new Dialogs.GastosDialog();
            frmNuevo1.valorTextBox.Focus();
            frmNuevo1.ShowDialog();
            if (frmNuevo1.DialogResult == DialogResult.OK)
            {
                string sqlInsert = string.Format("insert into gastos (fecha,valor,formapago,categoria,subcategoria,descripcion) values('{0}','{1}','{2}','{3}','{4}','{5}')", frmNuevo1.fechaDateTimePicker.Value.ToString("yyyy-MM-dd"), frmNuevo1.valorTextBox.Text.Trim(), frmNuevo1.formapagoComboBox.Text, frmNuevo1.categoriaComboBox.Text, frmNuevo1.subcategoriaComboBox.Text, frmNuevo1.descripcionTextBox.Text.Trim());
                if (aConexion.AccionSQL(sqlInsert) == true)
                {

                    this.frmGastosList_Load(null, null);
                    MessageBox.Show("La información de sus gastos ha sido Guardada correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gastosDataGridView.Focus();
                }
            }

        }

        private void btnCerrar1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (gastosBindingSource.Count > 0)
            {
                Dialogs.GastosDialog frmEditar1 = new Dialogs.GastosDialog();
                DataGridViewRow Fila = gastosDataGridView.CurrentRow;
                Int16 ID = Int16.Parse(Fila.Cells[0].Value.ToString());
                frmEditar1.fechaDateTimePicker.Value = Convert.ToDateTime(Fila.Cells[1].Value);
                frmEditar1.valorTextBox.Text = Fila.Cells[2].Value.ToString();
                frmEditar1.formapagoComboBox.Text = Fila.Cells[3].Value.ToString();
                frmEditar1.categoriaComboBox.Text = Fila.Cells[4].Value.ToString();
                frmEditar1.subcategoriaComboBox.Text = Fila.Cells[5].Value.ToString();
                frmEditar1.descripcionTextBox.Text = Fila.Cells[6].Value.ToString();
                frmEditar1.valorTextBox.Focus();
                frmEditar1.ShowDialog();
                if (frmEditar1.DialogResult == DialogResult.OK)
                {
                    string sqlUpdate = string.Format("update gastos set fecha='{0}', valor='{1}', formapago='{2}', categoria='{3}', subcategoria='{4}', descripcion='{5}' where ID ={6}", frmEditar1.fechaDateTimePicker.Value.ToString("yyyy-MM-dd"), frmEditar1.valorTextBox.Text.Trim(), frmEditar1.formapagoComboBox.Text, frmEditar1.categoriaComboBox.Text, frmEditar1.subcategoriaComboBox.Text, frmEditar1.descripcionTextBox.Text.Trim(), ID);
                    if (aConexion.AccionSQL(sqlUpdate) == true)
                    {
                        this.frmGastosList_Load(null, null);
                        MessageBox.Show("La información de su compra ha sido actualizada.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gastosDataGridView.Focus();
                    }
                }
            }

        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (gastosBindingSource.Count > 0)
            {
                if (MessageBox.Show("Asegurese de quere eliminar la informacion del producto. Desea eliminar permanentemente este registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataGridViewRow Fila = gastosDataGridView.CurrentRow;
                    Int16 ID = Int16.Parse(Fila.Cells[0].Value.ToString());
                    string sqlDelete = string.Format("delete from gastos where id ={0}", ID);
                    if (aConexion.AccionSQL(sqlDelete) == true)
                    {
                        this.frmGastosList_Load(null, null);
                        MessageBox.Show("La información del Producto comprado ha sido borrada permanentemente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gastosDataGridView.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay información para eliminar un registro.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {

            if (cmdbuscarpor1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una de las occiones para buscar un Producto ya sea por Categoria o por SubCategoria o por Descripcion", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmdbuscarpor1.Focus();
                return;
            }
            else
            {
                if (txtCriterio.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Por favor escriba un criterio para realizar la busqueda de un Producto .", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCriterio.Focus();
                    return;
                }
                else
                {
                    string sqlSelect = string.Empty;
                    switch (cmdbuscarpor1.SelectedIndex)
                    {
                        case 0://Categoria
                            sqlSelect = string.Format("Select * from gastos where categoria ='{0}'",
                                txtCriterio.Text.Trim());
                            break;
                        case 1://SubCAtegoria
                            sqlSelect = string.Format("Select * from gastos where subcategoria like '{0}%'", txtCriterio.Text.Trim());
                            break;
                        default://Descripcion
                            sqlSelect = string.Format("Select * from gastos where descripcion like '{0}%'", txtCriterio.Text.Trim());
                            break;

                    }
                    dslistadegastos.Gastos.Clear();
                    if (aConexion.selectData(sqlSelect, dslistadegastos.Gastos) == true)
                        gastosDataGridView.Focus();
                }
            }
        }
    }
}




