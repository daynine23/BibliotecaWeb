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
    public class LibroADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        Boolean blnexito = false;


        // Metodos de mantenimiento
        public Boolean InsertarLibro(LibroBE objLibroBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertarLibro";
            try
            {
                //Agregamos parametros 
                
                cmd.Parameters.AddWithValue("@id_Aut", objLibroBE.Id_Autor);
                cmd.Parameters.AddWithValue("@id_Cat", objLibroBE.Id_Categoria);
                cmd.Parameters.AddWithValue("@id_Edit", objLibroBE.Id_Editorial);
                cmd.Parameters.AddWithValue("@id_Idi", objLibroBE.Id_Idioma);
                cmd.Parameters.AddWithValue("@Tit", objLibroBE.Tit_Libro);
                cmd.Parameters.AddWithValue("@año_lanz", objLibroBE.Año_Lanz);
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
        
        public Boolean ActualizarLibro(LibroBE objLibroBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ActualizarLibro";
            //Agregamos parametros 
            try
            {
                //Codifique
                cmd.Parameters.AddWithValue("@id_Libro", objLibroBE.Id_Libro);
                cmd.Parameters.AddWithValue("@Tit", objLibroBE.Tit_Libro);
                cmd.Parameters.AddWithValue("@id_Aut", objLibroBE.Id_Autor);
                cmd.Parameters.AddWithValue("@id_Cat", objLibroBE.Id_Categoria);
                cmd.Parameters.AddWithValue("@id_Edit", objLibroBE.Id_Editorial);
                cmd.Parameters.AddWithValue("@id_Idi", objLibroBE.Id_Idioma);
                cmd.Parameters.AddWithValue("@año_lanz", objLibroBE.Año_Lanz);
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
        
        public Boolean EliminarLibro(String strcod)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EliminarLibro";
            //Agregamos parametros 
            try
            {
                //Codifique
                cmd.Parameters.AddWithValue("@id_Libro", strcod);
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

        public LibroBE ConsultarLibro(String strcod)
        {
            LibroBE objLibroBE = new LibroBE();
            try
            {
                //Codifique
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarLibro";

                cmd.Parameters.AddWithValue("@id_Libro", strcod);
                cnx.Open();
                dtr = cmd.ExecuteReader();

                if (dtr.HasRows == true)
                {
                    dtr.Read();

                    if (dtr["IdLibro"] == DBNull.Value)
                    {
                        objLibroBE.Id_Libro = "";
                    }
                    else
                    {
                        objLibroBE.Id_Libro = dtr["IdLibro"].ToString();
                    }


                    if (dtr["Titulo"] == DBNull.Value)
                    {
                        objLibroBE.Tit_Libro = "";
                    }
                    else
                    {
                        objLibroBE.Tit_Libro = dtr["Titulo"].ToString();
                    }


                    if (dtr["idAutor"] == DBNull.Value)
                    {
                        objLibroBE.Id_Autor = "";
                    }
                    else
                    {
                        objLibroBE.Id_Autor = dtr["idAutor"].ToString();
                    }


                    if (dtr["IdCategoria"] == DBNull.Value)
                    {
                        objLibroBE.Id_Categoria = "";
                    }
                    else
                    {
                        objLibroBE.Id_Categoria = dtr["IdCategoria"].ToString();
                    }

                    if (dtr["IdEditorial"] == DBNull.Value)
                    {
                        objLibroBE.Id_Editorial = "";
                    }
                    else
                    {
                        objLibroBE.Id_Editorial = dtr["IdEditorial"].ToString();
                    }

                    if (dtr["IdIdioma"] == DBNull.Value)
                    {
                        objLibroBE.Id_Idioma = "";
                    }
                    else
                    {
                        objLibroBE.Id_Idioma =  dtr["IdIdioma"].ToString();
                    }

                    if (dtr["Año_Lanz"] == DBNull.Value)
                    {
                        objLibroBE.Año_Lanz = "";
                    }
                    else
                    {
                        objLibroBE.Año_Lanz = dtr["Año_Lanz"].ToString();
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
            return objLibroBE;
        }



        public DataTable ListarLibro()
        {
            DataSet dts = new DataSet();
            try
            {
                //Codifique
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarLibro";

                SqlDataAdapter ada;
                ada = new SqlDataAdapter(cmd);

                ada.Fill(dts, "Libros");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dts.Tables["Libros"];
        }
    }
}
