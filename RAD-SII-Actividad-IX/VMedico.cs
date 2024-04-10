using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.BaseDatos.Models;
using Negocio;

namespace RAD_SII_Actividad_IX
{
    public partial class VMedico : Form
    {
        private NMedico nMedico;
        public VMedico()
        {
            InitializeComponent();
            nMedico = new NMedico();
        }

        private void cargarDatos()
        {
            DGVDatos.DataSource = nMedico.TodosLosMedicos();
        }

        private void LimpiarDatos()
        {
            TxtMedicoId.Text = "";
            TxtNombre.Text = "";
            TxtApellido.Text = "";
            CHKActivo.Checked = false;
            btnEliminar.BackColor = Color.White;
            errorProvider1.Clear();
        }

        private bool ValidarDatos()
        {
            var FormularioValido = true;
            if (string.IsNullOrEmpty(TxtNombre.Text.ToString()) || string.IsNullOrWhiteSpace(TxtNombre.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtNombre, "Debe ingresar el Nombre de cliente");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(TxtApellido.Text.ToString()) || string.IsNullOrWhiteSpace(TxtApellido.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtApellido, "Debe ingresar el Apellido del cliente");
                return FormularioValido;
            }
            return FormularioValido;
        }

        private void CHKActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKActivos.Checked == true)
            {
                DGVDatos.DataSource = nMedico.MedicosActivos();
            }
            else
            {
                cargarDatos();
            }
        }

        private void DGVDatos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtMedicoId.Text = DGVDatos.CurrentRow.Cells["MedicoId"].Value.ToString();
            TxtNombre.Text = DGVDatos.CurrentRow.Cells["Nombre"].Value.ToString();
            TxtApellido.Text = DGVDatos.CurrentRow.Cells["Apellido"].Value.ToString();
            CHKActivo.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            btnEliminar.Enabled = false;
        }

        private void DGVDatos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtMedicoId.Text = DGVDatos.CurrentRow.Cells["MedicoId"].Value.ToString();
            TxtNombre.Text = DGVDatos.CurrentRow.Cells["Nombre"].Value.ToString();
            TxtApellido.Text = DGVDatos.CurrentRow.Cells["Apellido"].Value.ToString();
            CHKActivo.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            btnEliminar.Enabled = true;
            btnEliminar.BackColor = Color.Red;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Medico medico = new Medico()
                {
                    Nombre = TxtNombre.Text.ToString(),
                    Apellido = TxtApellido.Text.ToString(),
                    FechaIngreso = DateTime.Now,
                    Estado = CHKActivo.Checked
                };
                if (!string.IsNullOrEmpty(TxtMedicoId.Text) || !string.IsNullOrWhiteSpace(TxtMedicoId.Text))
                {
                    if (int.Parse(TxtMedicoId.Text.ToString()) != 0)
                    {
                        medico.MedicoId = int.Parse(TxtMedicoId.Text.ToString());
                    }
                }
                nMedico.EditarMedicos(medico);
                LimpiarDatos();
                cargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtMedicoId.Text.ToString()) ||
           !string.IsNullOrWhiteSpace(TxtMedicoId.Text.ToString()))
            {
                if (int.Parse(TxtMedicoId.Text.ToString()) != 0)
                {
                    var MedicoId = int.Parse(TxtMedicoId.Text.ToString());
                    nMedico.EliminarMedicos(MedicoId);
                    cargarDatos();
                }
            }
        }

        private void VMedico_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
