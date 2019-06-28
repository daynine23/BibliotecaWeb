using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaADO
{
    public class IdiomaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr = default(SqlDataReader);

        //Colocar aqui los demas  metodos de mantenimiento

        public DataTable ListarIdioma()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarIdioma";
                SqlDataAdapter miada = new SqlDataAdapter();
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Idiomas");
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el listado: " + ex.Message);
            }
            return dts.Tables["Idiomas"];
        }
    }
}
