using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class EnchereDAL
    {
        public EnchereDAL()
        { }

        public static ObservableCollection<EnchereDAO> selectEncheres()
        {
            ObservableCollection<EnchereDAO> l = new ObservableCollection<EnchereDAO>();
            string query = "SELECT * FROM enchere;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EnchereDAO p = new EnchereDAO(reader.GetInt32(0), reader.GetDouble(1), reader.GetDateTime(2),reader.GetInt32(3)
                                                    ,reader.GetInt32(4),reader.GetInt32(5), 
                                                    reader.GetInt32(6), reader.GetInt32(7));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Enchere : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateEnchere(EnchereDAO p)
        {
            string query = "UPDATE enchere set prixEnchere=\"" + p.prixEnchereDAO + "\", dateEnchere=\"" + p.dateEnchereDAO 
                           + "\", adjuge=\"" + p.adjugeDAO + "\", idCommissaire=\"" + p.idCommissairePriseurEnchereDAO + "\", idUtilisateur=\"" + p.idUtilisateurEnchereDAO
                           + "\", idLot=\"" + p.idLotEnchereDAO + "\", idOrdreAchat=\"" + p.idOrdreAchatEnchereDAO
                           + "\" where idEnchere=" + p.idEnchereDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEnchere(EnchereDAO p)
        {
            int id = getMaxIdEnchere() + 1;
            String dateEnchere = p.dateEnchereDAO.ToString("yyyy-MM-dd");
            
            string query = "INSERT INTO enchere VALUES (\"" + id + "\",\"" + p.prixEnchereDAO + "\",\"" + dateEnchere + "\",\"" + p.adjugeDAO + "\",\"" 
                           + p.idCommissairePriseurEnchereDAO + "\",\"" + p.idUtilisateurEnchereDAO + "\",\"" + p.idLotEnchereDAO + "\",\"" + p.idOrdreAchatEnchereDAO + "\");";
            
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEnchere(int id)
        {
            string query = "DELETE FROM enchere WHERE idEnchere = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdEnchere()
        {
            int maxIdEnchere = 0;
            string query = "SELECT MAX(idEnchere) FROM enchere;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdEnchere = reader.GetInt32(0);
                }
                else
                {
                    maxIdEnchere = 0;
                }
            }
            reader.Close();
            return maxIdEnchere;
        }

        public static EnchereDAO getEnchere(int idEnchere)
        {
            string query = "SELECT * FROM enchere WHERE id=" + idEnchere + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EnchereDAO pers = new EnchereDAO(reader.GetInt32(0), reader.GetDouble(1), reader.GetDateTime(2),reader.GetInt32(3)
                ,reader.GetInt32(4),reader.GetInt32(5), 
                reader.GetInt32(6), reader.GetInt32(7));
            reader.Close();
            return pers;
        }
    }
}