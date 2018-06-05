using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using RegistroPrimerParcial.BLL;
using RegistroPrimerParcial.Entidades;

namespace RegistroPrimerParcial.UI.Consultas
{
    public partial class ConsultarForm : Form
    {
        public ConsultarForm()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Grupos, bool>> filtro = g => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del grupo.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = g => g.GrupoId == id;
                    break;
                case 1://Filtrando por la fecha del grupo.
                    filtro = g => g.Fecha >= DesdeDateTimePicker.Value && g.Fecha <= HastaDateTimePicker.Value;
                    break;
                case 2://Filtrando por Descripcion del grupo.
                    filtro = g => g.Descripcion.Contains(CriterioTextBox.Text) && g.Fecha >= DesdeDateTimePicker.Value && g.Fecha <= HastaDateTimePicker.Value;
                    break;
                case 3://Filtrando por Cantidad de integrantes del grupo.
                    filtro = g => g.Cantidad.Equals(CriterioTextBox.Text) && g.Fecha >= DesdeDateTimePicker.Value && g.Fecha <= HastaDateTimePicker.Value;
                    break;
                case 4://Filtrando por Cantidad de grupos.
                    filtro = g => g.GrupoCant.Equals(CriterioTextBox.Text) && g.Fecha >= DesdeDateTimePicker.Value && g.Fecha <= HastaDateTimePicker.Value;
                    break;
                case 5://Filtrando por Integrantes de grupos.
                    filtro = g => g.Integrantes.Equals(CriterioTextBox.Text) && g.Fecha >= DesdeDateTimePicker.Value && g.Fecha <= HastaDateTimePicker.Value;
                    break;
            }

            ConsultaDataGridView.DataSource = BLL.GruposBLL.GeTList(filtro);
        }

        private void FiltroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltroComboBox.SelectedIndex == 1)
                CriterioTextBox.Enabled = false;
            else
                CriterioTextBox.Enabled = true;
        }
    }
}
