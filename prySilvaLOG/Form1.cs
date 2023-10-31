using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySilvaLOG
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        clsAccesoBD AccesoBD = new clsAccesoBD();
        private void CargarGrilla()
        {
            AccesoBD.TraerDatosDataSet(dgvDatos);
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            AccesoBD.ConectarBaseDatos();
            lblEstadoConexion.Text = AccesoBD.ConectionState;
            CargarGrilla();
        }

    }
}
