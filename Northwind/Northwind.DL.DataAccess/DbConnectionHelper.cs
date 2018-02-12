using System;
using System.Configuration;

namespace Northwind.DL.DataAccess
{
    class DbConnectionHelper
    {
        public const string CONNECTION_STRING_KEY = "NorthwindDB";

        public static string ObtenerCadenaConexion()
        {
            string strCadenaConexion;
            strCadenaConexion = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_KEY].ConnectionString;
            return strCadenaConexion;
        }

    }
}
