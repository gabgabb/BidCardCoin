using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class LotDAL
    {
        public LotDAL()
        { }

        public static ObservableCollection<LotDAO> selectLots()
        {
            ObservableCollection<LotDAO> l = new ObservableCollection<LotDAO>();
            string query = "SELECT * FROM lot;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LotDAO p = new LotDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Lot : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateLot(LotDAO p)
        {
            string query = "UPDATE lot set nomLot=\"" + p.nomLotDAO + "\", descriptionLot=\"" + p.descriptionLotDAO  + "\" where idLot=" + p.idLotDAO+ ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertLot(LotDAO p)
        {
            int id = getMaxIdLot() + 1;
            
            string query = "INSERT INTO lot VALUES (\"" + id + "\",\"" + p.nomLotDAO + "\",\"" + p.descriptionLotDAO+ "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerLot(int id)
        {
            string query = "DELETE FROM lot WHERE idLot = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdLot()
        {
            int maxIdLot = 0;
            string query = "SELECT MAX(idLot) FROM lot;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdLot = reader.GetInt32(0);
                }
                else
                {
                    maxIdLot = 0;
                }
            }
            reader.Close();
            return maxIdLot;
        }

        public static LotDAO getLot(int idLot)
        {
            string query = "SELECT * FROM lot WHERE id=" + idLot + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LotDAO pers = new LotDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            reader.Close();
            return pers;
        }
    }
}