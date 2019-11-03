﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class DataProvider
    {
        //chuỗi kết nối
        SqlConnection connection;

        //tạo biến singleton
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider()
        {
            string con = @"Data Source=.;Initial Catalog=QuanLyHoTroDatVe;Integrated Security=True";
            connection = new SqlConnection(con);
        }
        
        //kiểm tra kết nối
        public void Connect()
        {
            if (connection != null && connection.State == ConnectionState.Closed)
                try
                {
                    connection.Open();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
        }
        public void Disconnect()
        {
            if(connection != null && connection.State == ConnectionState.Open)
                try
                {
                    connection.Close();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
        }

        public DataTable ExecuteQuery( string query)
        {
            Connect();
            DataTable tableResult = new DataTable();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(tableResult);
            Disconnect();
            return tableResult;
        }

        public int ExecuteNonQuery( string query)
        {
            Connect();
            int result = 0;
            SqlCommand command = new SqlCommand(query, connection);
            result = command.ExecuteNonQuery();
            Disconnect();
            return result;
        }

    }
}
