using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Northwind.BL.Entities;

namespace Northwind.DL.DataAccess
{
    public class Proveedores
    {

        public List<Proveedor> ListarProveedores()
        {
            SqlConnection cnx = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Proveedor objProveedor;
            List<Proveedor> lstProveedores = new List<Proveedor>();

            try
            {
                cnx.ConnectionString = DbConnectionHelper.ObtenerCadenaConexion();
                cnx.Open();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ListAllSuppliers";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        objProveedor = new Proveedor();
                        objProveedor.Id = (int)reader["SupplierID"];
                        objProveedor.Nombre = reader["CompanyName"].ToString();
                        objProveedor.NombreContacto = reader["ContactName"].ToString();
                        objProveedor.TituloContacto = reader["ContactTitle"].ToString();
                        objProveedor.Direccion = reader["Address"].ToString();
                        objProveedor.Ciudad = reader["City"].ToString();
                        objProveedor.Region = reader["Region"].ToString();
                        objProveedor.CodigoPostal = reader["PostalCode"].ToString();
                        objProveedor.Pais = reader["Country"].ToString();
                        objProveedor.Telefono= reader["Phone"].ToString();
                        objProveedor.Fax = reader["Fax"].ToString();
                        objProveedor.SitioWeb = reader["HomePage"].ToString();
                        lstProveedores.Add(objProveedor);
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
            return lstProveedores;
        }

    }
}
