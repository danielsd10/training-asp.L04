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

        public Proveedor ObtenerProveedor(int Id)
        {
            SqlConnection cnx = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlParameter param;
            Proveedor objProveedor = null;

            try
            {
                cnx.ConnectionString = DbConnectionHelper.ObtenerCadenaConexion();
                cnx.Open();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetSupplier";
                param = new SqlParameter();
                param.ParameterName = "@SupplierID";
                param.DbType = DbType.Int32;
                param.Value = Id;
                cmd.Parameters.Add(param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
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
                        objProveedor.Telefono = reader["Phone"].ToString();
                        objProveedor.Fax = reader["Fax"].ToString();
                        objProveedor.SitioWeb = reader["HomePage"].ToString();
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
            return objProveedor;
        }

        public bool InsertarProveedor(Proveedor objProveedor)
        {
            SqlConnection cnx = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlParameter param;
            int result = -1;

            try
            {
                cnx.ConnectionString = DbConnectionHelper.ObtenerCadenaConexion();
                cnx.Open();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertSupplier";

                param = new SqlParameter();
                param.ParameterName = "@CompanyName";
                param.DbType = DbType.String;
                param.Value = objProveedor.Nombre;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@ContactName";
                param.DbType = DbType.String;
                param.Value = objProveedor.NombreContacto;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@ContactTitle";
                param.DbType = DbType.String;
                param.Value = objProveedor.TituloContacto;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Address";
                param.DbType = DbType.String;
                param.Value = objProveedor.Direccion;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@City";
                param.DbType = DbType.String;
                param.Value = objProveedor.Ciudad;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Region";
                param.DbType = DbType.String;
                param.Value = objProveedor.Region;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@PostalCode";
                param.DbType = DbType.String;
                param.Value = objProveedor.CodigoPostal;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Country";
                param.DbType = DbType.String;
                param.Value = objProveedor.Pais;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Phone";
                param.DbType = DbType.String;
                param.Value = objProveedor.Telefono;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Fax";
                param.DbType = DbType.String;
                param.Value = objProveedor.Telefono;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@HomePage";
                param.DbType = DbType.String;
                param.Value = objProveedor.SitioWeb;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();

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
            return result > 0;
        }

        public bool ActualizarProveedor(Proveedor objProveedor)
        {
            SqlConnection cnx = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlParameter param;
            int result = -1;

            try
            {
                cnx.ConnectionString = DbConnectionHelper.ObtenerCadenaConexion();
                cnx.Open();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateSupplier";

                param = new SqlParameter();
                param.ParameterName = "@SupplierID";
                param.DbType = DbType.Int32;
                param.Value = objProveedor.Id;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@CompanyName";
                param.DbType = DbType.String;
                param.Value = objProveedor.Nombre;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@ContactName";
                param.DbType = DbType.String;
                param.Value = objProveedor.NombreContacto;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@ContactTitle";
                param.DbType = DbType.String;
                param.Value = objProveedor.TituloContacto;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Address";
                param.DbType = DbType.String;
                param.Value = objProveedor.Direccion;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@City";
                param.DbType = DbType.String;
                param.Value = objProveedor.Ciudad;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Region";
                param.DbType = DbType.String;
                param.Value = objProveedor.Region;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@PostalCode";
                param.DbType = DbType.String;
                param.Value = objProveedor.CodigoPostal;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Country";
                param.DbType = DbType.String;
                param.Value = objProveedor.Pais;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Phone";
                param.DbType = DbType.String;
                param.Value = objProveedor.Telefono;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Fax";
                param.DbType = DbType.String;
                param.Value = objProveedor.Telefono;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@HomePage";
                param.DbType = DbType.String;
                param.Value = objProveedor.SitioWeb;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();

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
            return result > 0;
        }

        public bool EliminarProveedor(int Id)
        {
            SqlConnection cnx = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlParameter param;
            int result = -1;

            try
            {
                cnx.ConnectionString = DbConnectionHelper.ObtenerCadenaConexion();
                cnx.Open();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteSupplier";

                param = new SqlParameter();
                param.ParameterName = "@SupplierID";
                param.DbType = DbType.Int32;
                param.Value = Id;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();

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
            return result > 0;
        }

    }
}
