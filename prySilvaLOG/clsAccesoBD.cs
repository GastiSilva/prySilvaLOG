using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace prySilvaLOG
{
    internal class clsAccesoBD
    {
        OleDbCommand comandoBD;
        OleDbDataReader lectorBD;
        OleDbDataAdapter adaptadorDS;
        OleDbConnection conexionBD;
        DirectoryInfo rutaProyecto = new DirectoryInfo(@"../..");
        string cadenaConexion;
        public bool estadoConexion;
        public string ConectionState;
        DataSet objDataSet = new DataSet();

        public clsAccesoBD()
        {
            estadoConexion = false;
            cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source="
                + rutaProyecto.FullName + "\\Base\\LOG.accdb";
        }

        public void ConectarBaseDatos()
        {
            conexionBD = new OleDbConnection(cadenaConexion);
            conexionBD.Open();
            estadoConexion = true;
            ConectionState = "conectado";
        }

        public void TraerDatosDataSet(DataGridView grilla)
        {
            try
            {
                ConectarBaseDatos();
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Registros";

                adaptadorDS = new OleDbDataAdapter(comandoBD);
                adaptadorDS.Fill(objDataSet, "Registros");

                if (objDataSet.Tables["Registros"].Rows.Count > 0)
                {
                    grilla.Columns.Add("ID", "ID");
                    grilla.Columns.Add("Categoria", "Categoria");
                    grilla.Columns.Add("Fecha Hora", "Fecha Hora");
                    grilla.Columns.Add("Descripcion", "Descripcion");

                    foreach (DataRow fila in objDataSet.Tables[0].Rows)
                    {
                        grilla.Rows.Add(fila[0], fila[1], fila[2]);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}