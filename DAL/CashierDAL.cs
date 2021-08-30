using System;
using Persistance;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class CashierDAL
    {
        public int Login(Cashier Cashier)
        {
            int login = 0;
            try{
                MySqlConnection connection = DbHelper.GetConnection();
                connection.Open();
                string query = "select * from Cashier where userName='" + Cashier.UserName + "' and password='" + Md5Algorithms.CreateMD5(Cashier.Password) + "';";
                MySqlDataReader reader = DbHelper.ExecQuery(query);
                if (reader.Read())
                {
                    login = reader.GetInt32("role");
                }
                else
                {
                    login = 0;
                }
                reader.Close();
                connection.Close();
            }catch{
                login = -1;
            }
            return login;
        }
    }
}