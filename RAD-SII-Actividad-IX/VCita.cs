using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Datos.BaseDatos.Models;
using Negocio;

namespace RAD_SII_Actividad_IX
{
    public partial class VCita : Form
    {
        private NCita nCita;
        private NMedico nMedico;
        private NPaciente nPaciente;
        public VCita()
        {
            InitializeComponent();
            nCita = new NCita();
            nMedico = new NMedico();
            nPaciente = new NPaciente();
        }

        private void cargarDatos()
        {
            var clientes = nCita.TodasLasCitas().Select(c => new { c.CitaId, c.MedicoId, c.Medico.Nombre, c.PacienteId, c.Paciente.Nombres, c.FechaCita, c.Estado});
            DGVDatos.DataSource = clientes.ToList();
        }
        private void CargarCombos()
        {

            CBXMedicoId.DataSource = nMedico.CargaCombo();
            CBXMedicoId.DisplayMember = "Nombres";
            CBXMedicoId.ValueMember = "Valor";

            CBXPacienteId.DataSource = nPaciente.CargaCombo();
            CBXPacienteId.DisplayMember = "Nombres";
            CBXPacienteId.ValueMember = "Valor";
        }
        private void LimpiarDatos()
        {
            TxtCitaId.Text = "";
            CHKActivo.Checked = false;
            DTPFechaCita.Value= DateTime.Now;
            btnEliminar.BackColor = Color.White;
            errorProvider1.Clear();
        }

        private bool ValidarDatos()
        {
            var FormularioValido = true;
            if (string.IsNullOrEmpty(CBXMedicoId.Text.ToString()) || string.IsNullOrWhiteSpace(CBXMedicoId.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(CBXMedicoId, "Debe ingresar el Medico Id");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(CBXPacienteId.Text.ToString()) || string.IsNullOrWhiteSpace(CBXPacienteId.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(CBXPacienteId, "Debe ingresar el Paciente Id");
                return FormularioValido;
            }
            return FormularioValido;
        }

        private void CHKActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKActivos.Checked == true)
            {
                DGVDatos.DataSource = nCita.CitasActivas();
            }
            else
            {
                cargarDatos();
            }
        }

        private void DGVDatos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtCitaId.Text = DGVDatos.CurrentRow.Cells["CitaId"].Value.ToString();
            var Medico = DGVDatos.CurrentRow.Cells["MedicoId"].Value.ToString();
            CBXMedicoId.SelectedValue = int.Parse(Medico);
            var Paciente = DGVDatos.CurrentRow.Cells["PacienteId"].Value.ToString();
            CBXPacienteId.SelectedValue = int.Parse(Paciente);
            DTPFechaCita.Value = DateTime.Parse(DGVDatos.CurrentRow.Cells["FechaCita"].Value.ToString());
            CHKActivo.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            btnEliminar.Enabled = false;
        }

        private void DGVDatos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtCitaId.Text = DGVDatos.CurrentRow.Cells["CitaId"].Value.ToString();
            var Medico = DGVDatos.CurrentRow.Cells["MedicoId"].Value.ToString();
            CBXMedicoId.SelectedValue = int.Parse(Medico);
            var Paciente = DGVDatos.CurrentRow.Cells["PacienteId"].Value.ToString();
            CBXPacienteId.SelectedValue = int.Parse(Paciente);
            DTPFechaCita.Value = DateTime.Parse(DGVDatos.CurrentRow.Cells["FechaCita"].Value.ToString());
            CHKActivo.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            btnEliminar.Enabled = true;
            btnEliminar.BackColor = Color.Red;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                Cita cita = new Cita()
                    {

                        MedicoId = int.Parse(CBXMedicoId.SelectedValue.ToString()),
                        PacienteId = int.Parse(CBXPacienteId.SelectedValue.ToString()),
                        FechaCita = DTPFechaCita.Value,
                        Estado = CHKActivo.Checked
                    };
                    if (!string.IsNullOrEmpty(TxtCitaId.Text) || !string.IsNullOrWhiteSpace(TxtCitaId.Text))
                    {
                        if (int.Parse(TxtCitaId.Text.ToString()) != 0)
                        {
                        cita.CitaId = int.Parse(TxtCitaId.Text.ToString());
                        }
                    nCita.Editarcita(cita);
                }
                    nCita.AgregarCita(cita);
                    LimpiarDatos();
                    cargarDatos();
                
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCitaId.Text.ToString()) ||
           !string.IsNullOrWhiteSpace(TxtCitaId.Text.ToString()))
            {
                if (int.Parse(TxtCitaId.Text.ToString()) != 0)
                {
                    var MedicoId = int.Parse(TxtCitaId.Text.ToString());
                    nCita.Eliminarcita(MedicoId);
                    cargarDatos();
                }
            }
        }

        private void VCita_Load(object sender, EventArgs e)
        {
            CargarCombos();
            cargarDatos();
        }
    }
}
