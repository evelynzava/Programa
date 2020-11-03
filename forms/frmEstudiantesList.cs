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
    public partial class frmEstudiantesList : Form
    {
        admConexion oConexion = new admConexion();
        public frmEstudiantesList()
        {
            InitializeComponent();
        }

        private void frmEstudiantesList_Load(object sender, EventArgs e)
        {
            dsClasesVirtuales.Estudiantes.Clear();
            string selectSQl = "Select * from estudiantes";
            if (oConexion.selectData(selectSQl, dsClasesVirtuales.Estudiantes) != true)
                MessageBox.Show("No se ha podido cargar ningun dato de estudiantes, contacte el departamento de desarrollo tecnico", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
     
        }

        private void estudiantesBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Dialogs.EstudianteDialog frmNuevo = new Dialogs.EstudianteDialog();
            frmNuevo.identidadTextBox.Focus();
            frmNuevo.ShowDialog();
            if (frmNuevo.DialogResult == DialogResult.OK)
            {
                string sqlInsert = string.Format("insert into estudiantes (identidad,nombres,apellidos,fechanac,sexo,direccion,obs) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", frmNuevo.identidadTextBox.Text.Trim(),frmNuevo.nombresTextBox.Text.Trim(),frmNuevo.apellidosTextBox.Text.Trim(),frmNuevo.fechanacDateTimePicker.Value.ToString("yyyy-MM-dd"),frmNuevo.sexoComboBox.Text, frmNuevo.direccionTextBox.Text.Trim(),frmNuevo.obsTextBox.Text.Trim());
                if (oConexion.AccionSQL(sqlInsert) == true)
                {
                    this.frmEstudiantesList_Load(null, null);
                    MessageBox.Show("La información de estudiante a sido almacenada correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estudiantesDataGridView.Focus();
                }
            }


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (estudiantesBindingSource.Count > 0)
            {
                Dialogs.EstudianteDialog frmEditar = new Dialogs.EstudianteDialog();
                DataGridViewRow Fila = estudiantesDataGridView.CurrentRow;
                Int16 ID = Int16.Parse(Fila.Cells[0].Value.ToString());
                frmEditar.identidadTextBox.Text = Fila.Cells[1].Value.ToString();
                frmEditar.nombresTextBox.Text = Fila.Cells[2].Value.ToString();
                frmEditar.apellidosTextBox.Text = Fila.Cells[3].Value.ToString();
                frmEditar.fechanacDateTimePicker.Value = Convert.ToDateTime(Fila.Cells[4].Value);
                frmEditar.sexoComboBox.Text = Fila.Cells[5].Value.ToString();
                frmEditar.direccionTextBox.Text = Fila.Cells[6].Value.ToString();
                frmEditar.obsTextBox.Text = Fila.Cells[7].Value.ToString();
                frmEditar.identidadTextBox.Focus();
                frmEditar.ShowDialog();
                if (frmEditar.DialogResult == DialogResult.OK)
                {
                    string sqlUpdate = string.Format("update estudiantes set identidad='{0}', nombres='{1}', apellidos='{2}', fechanac='{3}', sexo='{4}', direccion='{5}', obs='{6}' where id ={7}", frmEditar.identidadTextBox.Text.Trim(), frmEditar.nombresTextBox.Text.Trim(), frmEditar.apellidosTextBox.Text.Trim(), frmEditar.fechanacDateTimePicker.Value.ToString("yyyy-MM-dd"), frmEditar.sexoComboBox.Text, frmEditar.direccionTextBox.Text.Trim(), frmEditar.obsTextBox.Text.Trim(), ID);
                    if (oConexion.AccionSQL(sqlUpdate) == true)
                    {
                        this.frmEstudiantesList_Load(null, null);
                        MessageBox.Show("La información de estudiantes ha sido actualizada correctamente.","Editar",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        estudiantesDataGridView.Focus();
                    }

                }


            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(estudiantesBindingSource.Count > 0)
            {
                if (MessageBox.Show("Asegurese de quere eliminar la informacion del estudiante. Dessea eliminar permanentemente este registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataGridViewRow Fila = estudiantesDataGridView.CurrentRow;
                    Int16 ID = Int16.Parse(Fila.Cells[0].Value.ToString());
                    string sqlDelete = string.Format("delete from estudiantes where id ={0}", ID);
                    if (oConexion.AccionSQL(sqlDelete) == true)
                    {
                        this.frmEstudiantesList_Load(null, null);
                        MessageBox.Show("La información del estudiante ha sido borrada permanentemente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        estudiantesDataGridView.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay información para eliminar un registro.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmdBuscarPor.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una de las occiones para buscar un estudiante ya sea por identidad o por nombres o por apellidos", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmdBuscarPor.Focus();
                return;
            }
            else
            {
                if (txtCriterio.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Por favor escriba un criterio para realizar la busqueda de un estudiante.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCriterio.Focus();
                    return;
                }
                else
                {
                    string sqlSelect = string.Empty;
                    switch (cmdBuscarPor.SelectedIndex)
                    {
                        case 0://identidad
                            sqlSelect = string.Format("Select * from estudiantes where identidad ='{0}'", txtCriterio.Text.Trim());
                            break;
                        case 1://nombres
                            sqlSelect = string.Format("Select * from estudiantes where nombres like '{0}%'", txtCriterio.Text.Trim());
                            break;
                        default://Apellidos
                            sqlSelect = string.Format("Select * from estudiantes where apellidos like '{0}%'", txtCriterio.Text.Trim());
                            break;

                    }
                    dsClasesVirtuales.Estudiantes.Clear();
                    if (oConexion.selectData(sqlSelect, dsClasesVirtuales.Estudiantes) == true)
                        estudiantesDataGridView.Focus();
                }
            }

         }
       }
    }

 
