using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class AdresseDAL
    {
        public AdresseDAL()
        { }

        public static ObservableCollection<AdresseDAO> selectAdresses()
        {
            ObservableCollection<AdresseDAO> l = new ObservableCollection<AdresseDAO>();
            string query = "SELECT * FROM adresse;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AdresseDAO p = new AdresseDAO(reader.GetInt32(0), reader.GetInt32(1),reader.GetString(2), reader.GetString(3),reader.GetString(4), reader.GetString(5));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Adresse : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateAdresse(AdresseDAO p)
        {
            string query = "UPDATE adresse set numero=\"" + p.numeroDAO + "\", rue=\"" + p.rueDAO + "\", ville=\"" + p.villeDAO + "\", codePostal=\"" + p.codePostalDAO + "\", pays=\"" + p.paysDAO + "\" where idAdresse=" + p.idAdresseDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertAdresse(AdresseDAO p)
        {
            int id = getMaxIdAdresse() + 1;
            string query = "INSERT INTO adresse VALUES (\"" + id + "\",\"" + p.numeroDAO + "\",\"" + p.rueDAO+ "\",\"" + p.villeDAO  +  "\",\"" +  p.codePostalDAO + "\",\"" +  p.paysDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerAdresse(int id)
        {
            string query = "DELETE FROM adresse WHERE idAdresse = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdAdresse()
        {
            int maxIdAdresse = 0;
            string query = "SELECT MAX(idAdresse) FROM adresse;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdAdresse = reader.GetInt32(0);
                }
                else
                {
                    maxIdAdresse = 0;
                }
            }
            reader.Close();
            return maxIdAdresse;
        }

        public static AdresseDAO getAdresse(int idAdresse)
        {
            string query = "SELECT * FROM Adresse WHERE id=" + idAdresse + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            AdresseDAO pers = new AdresseDAO(reader.GetInt32(0), reader.GetInt32(1),reader.GetString(2), reader.GetString(3),reader.GetString(4), reader.GetString(5));
            reader.Close();
            return pers;
        }
    }
}