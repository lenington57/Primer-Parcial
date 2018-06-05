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
using RegistroPrimerParcial.DAL;

namespace RegistroPrimerParcial.UI.Registros
{
    public partial class RegistrarForm : Form
    {
        public RegistrarForm()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GrupoiIdNumericUpDown.Value);

            Grupos grupos = new Grupos();
            grupos = BLL.GruposBLL.Buscar(id);

            if (grupos != null)
            {
                FechaDateTimePicker.Value = grupos.Fecha;
                DescripcionTextBox.Text = grupos.Descripcion;
                CantidadTextBox.Text = grupos.Cantidad.ToString();
                GruposTextBox.Text = grupos.GrupoCant.ToString();
                IntegrantesTextBox.Text = grupos.Integrantes.ToString();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarForm_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        
        private Grupos LlenaClase()
        {
            Grupos grupos = new Grupos();

            grupos.GrupoId = Convert.ToInt32(GrupoiIdNumericUpDown.Value);
            grupos.Fecha = FechaDateTimePicker.Value;
            grupos.Descripcion = DescripcionTextBox.Text;
            grupos.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
            grupos.GrupoCant = Convert.ToInt32(GruposTextBox.Text);
            grupos.Integrantes = grupos.Cantidad / grupos.GrupoCant;

            IntegrantesTextBox.Text = grupos.Integrantes.ToString();
            return grupos;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            GrupoiIdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            DescripcionTextBox.Clear();
            CantidadTextBox.Clear();
            GruposTextBox.Clear();
            IntegrantesTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar())
            {
                MessageBox.Show("Complete estos campos", "Errores",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Grupos grupos = LlenaClase();
            
            if (GrupoiIdNumericUpDown.Value == 0)
                paso = BLL.GruposBLL.Guardar(grupos);
            else
                paso = BLL.GruposBLL.Modificar(grupos);

            if (paso)
                MessageBox.Show("Guardado!!", "Correcto!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se guardó!!","Falló",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GrupoiIdNumericUpDown.Value);

            if (BLL.GruposBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Correcto!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se eliminó!!", "Falló",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private bool Validar()
        {
            bool Error = false;

            if (GrupoiIdNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(GrupoiIdNumericUpDown, "No ha ingresado un ID");
                Error = true;
            }

            if (String.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                MyErrorProvider.SetError(DescripcionTextBox, "No ha ingresado una descripción");
                Error = true;
            }

            if (String.IsNullOrEmpty(CantidadTextBox.Text))
            {
                MyErrorProvider.SetError(CantidadTextBox, "No ha ingresado una cantidad de estudiantes");
                Error = true;
            }

            if (String.IsNullOrEmpty(GruposTextBox.Text))
            {
                MyErrorProvider.SetError(GruposTextBox, "No ha ingresado una cantidad de grupos");
                Error = true;
            }

            return Error;
        }
    }
}
