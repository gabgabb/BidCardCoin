using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class StockageDAL
    {
        public StockageDAL()
        { }

        public static ObservableCollection<StockageDAO> selectStockages()
        {
            ObservableCollection<StockageDAO> l = new ObservableCollection<StockageDAO>();
            string query = "SELECT * FROM stockage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StockageDAO p = new StockageDAO(reader.GetInt32(0), reader.GetInt32(1));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Stockage : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateStockage(StockageDAO p)
        {
            string query = "UPDATE stockage set idAdresseStockage=\"" + p.idAdresseStockageDAO + "\" where idStockage=" + p.idStockageDAO+ ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertStockage(StockageDAO p)
        {
            int id = getMaxIdStockage() + 1;
            
            string query = "INSERT INTO stockage VALUES (\"" + id + "\",\"" + p.idAdresseStockageDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerStockage(int id)
        {
            string query = "DELETE FROM stockage WHERE idStockage = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdStockage()
        {
            int maxIdStockage = 0;
            string query = "SELECT MAX(idStockage) FROM stockage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdStockage = reader.GetInt32(0);
                }
                else
                {
                    maxIdStockage = 0;
                }
            }
            reader.Close();
            return maxIdStockage;
        }

        public static StockageDAO getStockage(int idStockage)
        {
            string query = "SELECT * FROM stockage WHERE id=" + idStockage + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            StockageDAO pers = new StockageDAO(reader.GetInt32(0), reader.GetInt32(1));
            reader.Close();
            return pers;
        }
    }
}