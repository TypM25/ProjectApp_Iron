using System;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Npgsql;


namespace App_Iron
{
    public static class Center
    {

        public static NpgsqlConnection vCon = new NpgsqlConnection();

        public static NpgsqlCommand vCmd = new NpgsqlCommand("", vCon);


        private static string GetConnectionstring()
        {
            string conString = "Server =localhost ; port =5432 ; user id =postgres ; password =pin555 ; database =iron ;";
            return conString;
        }

        public static void openConnection()
        {
            if (vCon.State == ConnectionState.Closed)
            {
                vCon.ConnectionString = GetConnectionstring();
                vCon.Open();
            }
        }

        public static void closeConnection()
        {
            if (vCon.State == ConnectionState.Open)
            {
 
                vCon.Close();
            }
        }
    }



}
