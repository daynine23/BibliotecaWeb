using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaADO
{
    public class CategoriaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr = default(SqlDataReader);

        //Colocar aqui los demas  metodos de mantenimiento

        public DataTable ListarCategoria()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarCategoria";
                SqlDataAdapter miada = new SqlDataAdapter();
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Categorias");
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el listado: " + ex.Message);
            }
            return dts.Tables["Categorias"];
        }
    }
}
