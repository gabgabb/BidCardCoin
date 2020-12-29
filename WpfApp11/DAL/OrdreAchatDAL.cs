using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class OrdreAchatDAL
    { 
        public OrdreAchatDAL()
        { }

        public static ObservableCollection<OrdreAchatDAO> selectOrdreAchats()
        {
            ObservableCollection<OrdreAchatDAO> l = new ObservableCollection<OrdreAchatDAO>();
            string query = "SELECT * FROM ordreachat;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    OrdreAchatDAO p = new OrdreAchatDAO(reader.GetInt32(0), reader.GetDouble(1),reader.GetDateTime(2), reader.GetInt32(3),reader.GetInt32(4));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table OrdreAchat : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateOrdreAchat(OrdreAchatDAO p)
        {
            string query = "UPDATE ordreachat set prixMax=\"" + p.prixMaxDAO + "\", dateOrdre=\"" + p.DateOrdreDAO + "\", idUtilisateur=\"" + p.idUtilisateurOrdreDAO + "\", idProduit=\"" + p.idProduitOrdreDAO + "\" where idOrdreAchat=" + p.idOrdreAchatDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertOrdreAchat(OrdreAchatDAO p)
        {
            int id = getMaxIdOrdreAchat() + 1;
            string query = "INSERT INTO ordreachat VALUES (\"" + id + "\",\"" + p.prixMaxDAO + "\",\"" + p.DateOrdreDAO+ "\",\"" + p.idUtilisateurOrdreDAO  +  "\",\"" +  p.idProduitOrdreDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerOrdreAchat(int id)
        {
            string query = "DELETE FROM ordreachat WHERE idOrdreAchat = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdOrdreAchat()
        {
            int maxIdOrdreAchat = 0;
            string query = "SELECT MAX(idOrdreAchat) FROM ordreachat;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdOrdreAchat = reader.GetInt32(0);
                }
                else
                {
                    maxIdOrdreAchat = 0;
                }
            }
            reader.Close();
            return maxIdOrdreAchat;
        }

        public static OrdreAchatDAO getOrdreAchat(int idOrdreAchat)
        {
            string query = "SELECT * FROM ordreachat WHERE id=" + idOrdreAchat + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            OrdreAchatDAO pers = new OrdreAchatDAO(reader.GetInt32(0), reader.GetDouble(1),reader.GetDateTime(2), reader.GetInt32(3),reader.GetInt32(4));
            reader.Close();
            return pers;
        }
    }
}