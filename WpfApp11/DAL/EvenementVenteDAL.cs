using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class EvenementVenteDAL
    {
        public EvenementVenteDAL()
        { }

        public static ObservableCollection<EvenementVenteDAO> selectEvenementVentes()
        {
            ObservableCollection<EvenementVenteDAO> l = new ObservableCollection<EvenementVenteDAO>();
            string query = "SELECT * FROM EvenementVente;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EvenementVenteDAO p = new EvenementVenteDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),reader.GetInt32(4));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table EvenementVente : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateEvenementVente(EvenementVenteDAO p)
        {
            string query = "UPDATE EvenementVente set estVolontaireEvenementVente=\"" + p.estVolontaireEvenementVenteDAO + "\", nomEvenementVente=\"" + p.nomEvenementVenteDAO + "\", idCommissairePriseurEvenementVente=\"" + p.idCommissairePriseurEvenementVenteDAO + "\", idAdresseEvenementVenteDAO=\"" + p.idAdresseEvenementVenteDAO  + "\" where idEvenementVente=" + p.idEvenementVenteDAO+ ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEvenementVente(EvenementVenteDAO p)
        {
            int id = getMaxIdEvenementVente() + 1;
            
            string query = "INSERT INTO EvenementVente VALUES (\"" + id + "\",\"" + p.estVolontaireEvenementVenteDAO + "\",\"" + p.nomEvenementVenteDAO+ "\",\"" + p.idCommissairePriseurEvenementVenteDAO +  "\",\"" + p.idAdresseEvenementVenteDAO+ "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEvenementVente(int id)
        {
            string query = "DELETE FROM EvenementVente WHERE idEvenementVente = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdEvenementVente()
        {
            int maxIdEvenementVente = 0;
            string query = "SELECT MAX(idEvenementVente) FROM EvenementVente;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdEvenementVente = reader.GetInt32(0);
                }
                else
                {
                    maxIdEvenementVente = 0;
                }
            }
            reader.Close();
            return maxIdEvenementVente;
        }

        public static EvenementVenteDAO getEvenementVente(int idEvenementVente)
        {
            string query = "SELECT * FROM EvenementVente WHERE id=" + idEvenementVente + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EvenementVenteDAO pers = new EvenementVenteDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),reader.GetInt32(4));
            reader.Close();
            return pers;
        }
    }
}