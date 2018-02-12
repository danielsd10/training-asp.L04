using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Northwind.BL.Entities;

namespace Northwind.DL.DataAccess
{
    public class Categorias
    {

        public List<Categoria> ListarCategorias()
        {
            SqlConnection cnx = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Categoria objCategoria;
            List<Categoria> lstCategorias = new List<Categoria>();

            try
            {
                cnx.ConnectionString = DbConnectionHelper.ObtenerCadenaConexion();
                cnx.Open();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ListAllCategories";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        objCategoria = new Categoria();
                        objCategoria.Id = (int)reader["CategoryID"];
                        objCategoria.Nombre = reader["CategoryName"].ToString();
                        objCategoria.Descripcion = reader["Description"].ToString();
                        lstCategorias.Add(objCategoria);
                    }
                }
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
                cnx.Dispose();
                cnx.Close();
            }
            return lstCategorias;
        }

    }
}
