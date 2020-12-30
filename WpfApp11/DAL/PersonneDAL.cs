using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class PersonneDAL
    {
        public PersonneDAL()
        { }
    
        public static ObservableCollection<PersonneDAO> selectPersonnes()
        {
            ObservableCollection<PersonneDAO> l = new ObservableCollection<PersonneDAO>();
            string query = "SELECT * FROM personne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonneDAO p = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), 
                        reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), 
                        reader.GetString(5), reader.GetString(6),reader.GetInt32(7));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table personne : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updatePersonne(PersonneDAO p)
        {
            string query = "UPDATE personne set nomPersonne=\"" + p.nomPersonneDAO + "\", prenomPersonne=\"" + p.prenomPersonneDAO + "\", dateNaissanceDAO=\"" 
                           + p.dateNaisPersonneDAO + "\", emailDAO=\"" + p.emailDAO + "\", telephoneDAO=\"" + p.telephoneDAO  + "\", passwordDAO=\"" +  p.passwordDAO  
                           + "\", verifID=\"" +  p.verifIdDAO + "\" where idPersonne=" + p.idPersonneDAO + ";";
            
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPersonne(PersonneDAO p)
        {
            int id = getMaxIdPersonne() + 1;
            String dateNaissance = p.dateNaisPersonneDAO.ToString("yyyy-MM-dd");
            string query = "INSERT INTO personne VALUES (\"" + id + "\",\"" + p.nomPersonneDAO + "\",\"" + p.prenomPersonneDAO + "\",\"" + dateNaissance  
                           +  "\",\"" +  p.emailDAO + "\",\"" +  p.telephoneDAO 
                           +  "\",\"" +  p.passwordDAO + "\",\"" +  p.verifIdDAO + "\");";
            
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerPersonne(int id)
        {
            string query = "DELETE FROM personne WHERE idPersonne = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdPersonne()
        {
            int maxIdPersonne = 0;
            string query = "SELECT MAX(idPersonne) FROM personne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdPersonne = reader.GetInt32(0);
                }
                else
                {
                    maxIdPersonne = 0;
                }
            }
            reader.Close();
            return maxIdPersonne;
        }

        public static PersonneDAO getPersonne(int idPersonne)
        {
            string query = "SELECT * FROM personne WHERE id=" + idPersonne + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PersonneDAO pers = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), 
                reader.GetString(2),(DateTime)reader.GetDateTime(3), reader.GetString(4), 
                reader.GetString(5), reader.GetString(6),reader.GetInt32(7));
            reader.Close();
            return pers;
        }
    }
}
