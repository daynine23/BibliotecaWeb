using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BibliotecaBE;

namespace BibliotecaADO
{
    public class EjemplarADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        Boolean blnexito = false;

        public Boolean InsertarEjemplar(EjemplarBE objEjemplarBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertarEjemplar";
            try
            {
                //Agregamos parametros 

                cmd.Parameters.AddWithValue("@id_Libro", objEjemplarBE.Titulo);
                cmd.Parameters.AddWithValue("@estado", objEjemplarBE.Estado);
                cnx.Open();
                cmd.ExecuteNonQuery();
                blnexito = true;

                //Codifique
            }
            catch (SqlException x)
            {
                blnexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return blnexito;

        }

        public Boolean ActualizarEjemplar(EjemplarBE objEjemplarBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ActualizarEjemplar";
            //Agregamos parametros 
            try
            {
                //Codifique
                cmd.Parameters.AddWithValue("@id_Ejemplar", objEjemplarBE.Id_Ejemplar);
                cmd.Parameters.AddWithValue("@id_Libro", objEjemplarBE.Titulo);
                cmd.Parameters.AddWithValue("@estado", objEjemplarBE.Estado);
                cnx.Open();
                cmd.ExecuteNonQuery();
                blnexito = true;



            }
            catch (SqlException x)
            {
                blnexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return blnexito;

        }

        public EjemplarBE ConsultarEjemplar(String strcod)
        {
            EjemplarBE objEjemplarBE = new EjemplarBE();
            try
            {
                //Codifique
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarEjemplar";

                cmd.Parameters.AddWithValue("@id_Ejemplar", strcod);
                cnx.Open();
                dtr = cmd.ExecuteReader();

                if (dtr.HasRows == true)
                {
                    dtr.Read();

                    if (dtr["IdEjemplar"] == DBNull.Value)
                    {
                        objEjemplarBE.Id_Ejemplar = "";
                    }
                    else
                    {
                        objEjemplarBE.Id_Ejemplar = dtr["IdEjemplar"].ToString();
                    }


                    if (dtr["IdLibro"] == DBNull.Value)
                    {
                        objEjemplarBE.Titulo = "";
                    }
                    else
                    {
                        objEjemplarBE.Titulo = dtr["IdLibro"].ToString();
                    }


                    if (dtr["Estado"] == DBNull.Value)
                    {
                        objEjemplarBE.Estado = "";
                    }
                    else
                    {
                        objEjemplarBE.Estado = dtr["Estado"].ToString();
                    }

                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return objEjemplarBE;
        }


        public DataTable ListarEjemplar()
        {
            DataSet dts = new DataSet();
            try
            {
                //Codifique
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarEjemplar";

                SqlDataAdapter ada;
                ada = new SqlDataAdapter(cmd);

                ada.Fill(dts, "Ejemplares");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dts.Tables["Ejemplares"];
        }
    }
}
