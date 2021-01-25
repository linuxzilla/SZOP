using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Service
{
    public class DatabaseManager
    {
        #region Private variables

        private bool connectionIsActive = false;
        private MySqlConnection mysqlConnection = null;

        private static DatabaseManager _instance = null;

        #endregion

        #region Constructors

        private DatabaseManager()
        {
            connectionIsActive = false;
            mysqlConnection = new MySqlConnection("Server=localhost; database=szop; UID=root; password=passwd; charset=utf8;");
        }

        public static DatabaseManager Instance()
        {
            if (_instance == null) 
                _instance = new DatabaseManager();
            return _instance;
        }

        #endregion

        #region Methods / Functions

        public bool Connect()
        {
            if (!connectionIsActive)
            {
                mysqlConnection.Open();
                connectionIsActive = true;
            }
            return true;
        }

        public void Close()
        {
            if (connectionIsActive)
            {
                mysqlConnection.Close();
                connectionIsActive = false;
            }
        }

        public MySqlDataReader MyqlReader(string sqlQuery)
        {
            return new MySqlCommand(sqlQuery, mysqlConnection).ExecuteReader();
        }

        public int ExecuteNonQuery(string sqlQuery)
        {
            return new MySqlCommand(sqlQuery, mysqlConnection).ExecuteNonQuery();
        }
        #endregion
    }
}