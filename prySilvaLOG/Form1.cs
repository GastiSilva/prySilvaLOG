using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;


namespace prySilvaLOG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        clsLOGcs objAccesoaBase = new clsLOGcs();
        private void Form1_Load(object sender, EventArgs e)
        {
            objAccesoaBase.ConectarBaseDatos();
            sslblConexion.Text = objAccesoaBase.EstadoConexion;
            objAccesoaBase.RegistrarDatosDataSet();
            objAccesoaBase.TraerDatos(dgvDatos);

        }

    }
}
