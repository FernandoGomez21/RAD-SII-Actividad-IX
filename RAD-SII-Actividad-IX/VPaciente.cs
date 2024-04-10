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
    public partial class VPaciente : Form
    {
        private NPaciente nPaciente;
        public VPaciente()
        {
            InitializeComponent();
            nPaciente = new NPaciente();
        }

        private void cargarDatos()
        {
            DGVDatos.DataSource = nPaciente.TodosLosPacientes();
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
                DGVDatos.DataSource = nPaciente.PacientesActivos();
            }
            else
            {
                cargarDatos();
            }
        }

        private void DGVDatos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtMedicoId.Text = DGVDatos.CurrentRow.Cells["PacienteId"].Value.ToString();
            TxtNombre.Text = DGVDatos.CurrentRow.Cells["Nombres"].Value.ToString();
            TxtApellido.Text = DGVDatos.CurrentRow.Cells["Apellidos"].Value.ToString();
            CHKActivo.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            btnEliminar.Enabled = false;
        }

        private void DGVDatos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtMedicoId.Text = DGVDatos.CurrentRow.Cells["PacienteId"].Value.ToString();
            TxtNombre.Text = DGVDatos.CurrentRow.Cells["Nombres"].Value.ToString();
            TxtApellido.Text = DGVDatos.CurrentRow.Cells["Apellidos"].Value.ToString();
            CHKActivo.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            btnEliminar.Enabled = true;
            btnEliminar.BackColor = Color.Red;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Paciente paciente = new Paciente()
                {
                    Nombres = TxtNombre.Text.ToString(),
                    Apellidos = TxtApellido.Text.ToString(),
                    FechaIngreso = DateTime.Now,
                    Estado = CHKActivo.Checked
                };
                if (!string.IsNullOrEmpty(TxtMedicoId.Text) || !string.IsNullOrWhiteSpace(TxtMedicoId.Text))
                {
                    if (int.Parse(TxtMedicoId.Text.ToString()) != 0)
                    {
                        paciente.PacienteId = int.Parse(TxtMedicoId.Text.ToString());
                    }
                }
                nPaciente.EditarPaciente(paciente);
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
                    var PacienteId = int.Parse(TxtMedicoId.Text.ToString());
                    nPaciente.EliminarPaciente(PacienteId);
                    cargarDatos();
                }
            }
        }

        private void VPaciente_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
