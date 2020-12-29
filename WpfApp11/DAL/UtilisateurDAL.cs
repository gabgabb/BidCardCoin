using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class UtilisateurDAL
    {
        public UtilisateurDAL()
        { }

        public static ObservableCollection<UtilisateurDAO> selectUtilisateurs()
        {
            ObservableCollection<UtilisateurDAO> l = new ObservableCollection<UtilisateurDAO>();
            string query =
                "SELECT fk_idPersonne, nomPersonne, prenomPersonne, dateNaissance, Email, password, Telephone, verifId,modePaiement,verifSolvable,estFrancais FROM utilisateur INNER JOIN personne ON utilisateur.fk_idPersonne = personne.idPersonne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
        
        try

        {
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                UtilisateurDAO p = new UtilisateurDAO(reader.GetInt32(0), reader.GetString(1),
                    reader.GetString(2), reader.GetDateTime(3), reader.GetString(4),
                    reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetString(8),
                    reader.GetInt32(9), reader.GetInt32(10));
                l.Add(p);
            }
        }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Utilisateur : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateUtilisateur(UtilisateurDAO p)
        {
            string query = "UPDATE utilisateur set modePaiement=\"" + p._ModePaiementDAO  + "\", verifSolv=\"" +  p.verifSolvableDAO + "\", estFrancais=\"" +  p.estFrancaisDAO + "\" where idPersonne=" + p.idPersonneDAO + ";";
            
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        
        public static void insertUtilisateur(UtilisateurDAO p)
        {
            int id = PersonneDAL.getMaxIdPersonne();

            string query = "INSERT INTO utilisateur VALUES (\"" + id + "\",\"" + p._ModePaiementDAO 
                           +  "\",\""  +  p.verifSolvableDAO + "\",\"" +  p.estFrancaisDAO + "\");";
            
           MySqlCommand cmd1 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap1 = new MySqlDataAdapter(cmd1);
            cmd1.ExecuteNonQuery();
        }
        
        public static void supprimerUtilisateur(int id)
        {
            string query = "DELETE FROM utilisateur WHERE fk_idPersonne = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdUtilisateur()
        {
            int maxIdUtilisateur = 0;
            string query = "SELECT MAX(fk_idPersonne) FROM utilisateur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdUtilisateur = reader.GetInt32(0);
                }
                else
                {
                    maxIdUtilisateur = 0;
                }
            }
            reader.Close();
            return maxIdUtilisateur;
        }

        public static UtilisateurDAO getUtilisateur(int idPersonneUtilisateur)
        {
            string query = "SELECT * FROM utilisateur WHERE fk_idPersonne=" + idPersonneUtilisateur + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            UtilisateurDAO pers = new UtilisateurDAO(reader.GetInt32(0), reader.GetString(1),
                reader.GetString(2), reader.GetDateTime(3), reader.GetString(4),
                reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetString(8),
                reader.GetInt32(9), reader.GetInt32(10)); 
            
            reader.Close();
            return pers;
        }
    }
}