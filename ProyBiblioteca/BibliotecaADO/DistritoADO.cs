using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BibliotecaBE;

namespace BibliotecaADO
{
    public class DistritoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarDistrito()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarDistrito";
                SqlDataAdapter miada = new SqlDataAdapter();
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Distritos");
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el listado: " + ex.Message);
            }
            return dts.Tables["Distritos"];
        }

    }
}
