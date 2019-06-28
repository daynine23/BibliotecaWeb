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
    public class LectorADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        Boolean blnexito = false;

        public Boolean InsertarLector(LectorBE objLectorBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertarLector";
            try
            {
                //Agregamos parametros 

                cmd.Parameters.AddWithValue("@nom_lec", objLectorBE.Nom_Lector);
                cmd.Parameters.AddWithValue("@apePat_lec", objLectorBE.ApePat_Lector);
                cmd.Parameters.AddWithValue("@apeMat_lec", objLectorBE.ApeMat_Lector);
                cmd.Parameters.AddWithValue("@dni_lec", objLectorBE.Dni);
                cmd.Parameters.AddWithValue("@dir_lec", objLectorBE.Dir);
                cmd.Parameters.AddWithValue("@tel_lec", objLectorBE.Tel);
                cmd.Parameters.AddWithValue("@email_lec", objLectorBE.Email_Lector);
                cmd.Parameters.AddWithValue("@id_dis", objLectorBE.Id_Distrito);

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

        public Boolean ActualizarLector(LectorBE objLectorBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ActualizarLector";
            //Agregamos parametros 
            try
            {
                //Codifique
                cmd.Parameters.AddWithValue("@id_Lector", objLectorBE.Id_Lector);
                cmd.Parameters.AddWithValue("@nom_lec", objLectorBE.Nom_Lector);
                cmd.Parameters.AddWithValue("@apePat_lec", objLectorBE.ApePat_Lector);
                cmd.Parameters.AddWithValue("@apeMat_lec", objLectorBE.ApeMat_Lector);
                cmd.Parameters.AddWithValue("@dni_lec", objLectorBE.Dni);
                cmd.Parameters.AddWithValue("@dir_lec", objLectorBE.Dir);
                cmd.Parameters.AddWithValue("@tel_lec", objLectorBE.Tel);
                cmd.Parameters.AddWithValue("@email_lec", objLectorBE.Email_Lector);
                cmd.Parameters.AddWithValue("@id_dis", objLectorBE.Id_Distrito);

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

        public Boolean EliminarLector(String strcod)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EliminarLector";
            //Agregamos parametros 
            try
            {
                //Codifique
                cmd.Parameters.AddWithValue("@id_Lector", strcod);
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

        public LectorBE ConsultarLector(String strcod)
        {
            LectorBE objLectorBE = new LectorBE();
            try
            {
                //Codifique
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarLector";

                cmd.Parameters.AddWithValue("@id_Lector", strcod);
                cnx.Open();
                dtr = cmd.ExecuteReader();

                if (dtr.HasRows == true)
                {
                    dtr.Read();

                    if (dtr["IdLector"] == DBNull.Value)
                    {
                        objLectorBE.Id_Lector = "";
                    }
                    else
                    {
                        objLectorBE.Id_Lector = dtr["IdLector"].ToString();
                    }

                    if (dtr["Nombre_Lector"] == DBNull.Value)
                    {
                        objLectorBE.Nom_Lector = "";
                    }
                    else
                    {
                        objLectorBE.Nom_Lector = dtr["Nombre_Lector"].ToString();
                    }

                    if (dtr["Ape_Paterno"] == DBNull.Value)
                    {
                        objLectorBE.ApePat_Lector = "";
                    }
                    else
                    {
                        objLectorBE.ApePat_Lector = dtr["Ape_Paterno"].ToString();
                    }

                    if (dtr["Ape_Materno"] == DBNull.Value)
                    {
                        objLectorBE.ApeMat_Lector = "";
                    }
                    else
                    {
                        objLectorBE.ApeMat_Lector = dtr["Ape_Materno"].ToString();
                    }

                    if (dtr["Dni"] == DBNull.Value)
                    {
                        objLectorBE.Dni = "";
                    }
                    else
                    {
                        objLectorBE.Dni = dtr["Dni"].ToString();
                    }

                    if (dtr["Direccion_Lector"] == DBNull.Value)
                    {
                        objLectorBE.Dir = "";
                    }
                    else
                    {
                        objLectorBE.Dir = dtr["Direccion_Lector"].ToString();
                    }

                    if (dtr["Telefono"] == DBNull.Value)
                    {
                        objLectorBE.Tel = "";
                    }
                    else
                    {
                        objLectorBE.Tel = dtr["Telefono"].ToString();
                    }

                    if (dtr["Email_Lector"] == DBNull.Value)
                    {
                        objLectorBE.Email_Lector = "";
                    }
                    else
                    {
                        objLectorBE.Email_Lector = dtr["Email_Lector"].ToString();
                    }

                    if (dtr["IdDistrito"] == DBNull.Value)
                    {
                        objLectorBE.Id_Distrito = "";
                    }
                    else
                    {
                        objLectorBE.Id_Distrito = dtr["IdDistrito"].ToString();
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
            return objLectorBE;
        }


        public DataTable ListarLector()
        {
            DataSet dts = new DataSet();
            try
            {
                //Codifique
                
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarLector";
                SqlDataAdapter ada;
                ada = new SqlDataAdapter(cmd);

                ada.Fill(dts, "Lectores");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dts.Tables["Lectores"];
        }
    }
}
