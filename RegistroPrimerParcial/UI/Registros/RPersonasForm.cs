using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroPrimerParcial.BLL;
using RegistroPrimerParcial.Entidades;

namespace RegistroPrimerParcial.UI.Registros
{
    public partial class RPersonasForm : Form
    {
        public RPersonasForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RPersonasForm_Load(object sender, EventArgs e)
        {

        }

        private Personas LlenaClase()
        {
            Personas persona = new Personas();

            persona.PersonaId = Convert.ToInt32(IDNumericUpDown.Value);
            persona.Fecha = FechaDateTimePicker.Value;
            persona.Nombres = NombresTextBox.Text;
            persona.Direccion = DireccionTextBox.Text;
            persona.Cedula = CedulaMaskedTextBox.Text;
            persona.Telefono = TelefonoMaskedTextBox.Text;

            return persona;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            IDNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            NombresTextBox.Clear();
            DireccionTextBox.Clear();
            CedulaMaskedTextBox.Clear();
            TelefonoMaskedTextBox.Clear();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IDNumericUpDown.Value);
            Personas persona = BLL.PersonasBLL.Buscar(id);

            if (persona != null)
            {
                FechaDateTimePicker.Value = persona.Fecha;
                NombresTextBox.Text = persona.Nombres;
                DireccionTextBox.Text = persona.Direccion;
                CedulaMaskedTextBox.Text = persona.Cedula;
                TelefonoMaskedTextBox.Text = persona.Telefono;
            }
            else
                MessageBox.Show("No se encontró!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Personas persona;
            bool Paso = false;

            persona = LlenaClase();

            if (IDNumericUpDown.Value == 0)
                Paso = BLL.PersonasBLL.Guardar(persona);
            else
                Paso = BLL.PersonasBLL.Modificar(persona);

            if (Paso)

                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IDNumericUpDown.Value);

            if (BLL.PersonasBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }        
    }
}
