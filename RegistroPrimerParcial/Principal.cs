using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroPrimerParcial
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void registroGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroPrimerParcial.UI.Registros.RegistrarForm registrarForm = new UI.Registros.RegistrarForm();
            registrarForm.Show();
        }

        private void consultarGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroPrimerParcial.UI.Consultas.ConsultarForm consultarForm = new UI.Consultas.ConsultarForm();
            consultarForm.Show();
        }
    }
}
