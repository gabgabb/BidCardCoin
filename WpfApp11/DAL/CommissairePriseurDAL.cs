using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class CommissairePriseurDAL
    {
        public CommissairePriseurDAL()
        { }

        public static ObservableCollection<CommissairePriseurDAO> selectCommissairePriseurs()
        {
            ObservableCollection<CommissairePriseurDAO> l = new ObservableCollection<CommissairePriseurDAO>();
            string query =  "SELECT fk_idPersonne, nomPersonne, prenomPersonne, dateNaissance, Email, password, Telephone, verifId, EstVolontaire,Formation,verifFormation FROM commissairepriseur JOIN personne ON commissairepriseur.fk_idPersonne = personne.idPersonne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CommissairePriseurDAO p = new CommissairePriseurDAO(reader.GetInt32(0), reader.GetString(1), 
                        reader.GetString(2),(DateTime)reader.GetDateTime(3), reader.GetString(4), 
                        reader.GetString(5), reader.GetString(6),reader.GetInt32(7),reader.GetInt32(8),
                        reader.GetString(9), reader.GetInt32(10));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table CommissairePriseur : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateCommissairePriseur(CommissairePriseurDAO p)
        {
            string query = "UPDATE commissairepriseur set EstVolontaire=\"" + p.estVolontaireDAO + "\", Formation=\"" + p.formationDAO + "\", verifFormation=\"" + p.formationDAO                        
                            + "\" where fk_idPersonne=" + p.idPersonneCommissairePriseurDAO + ";";
            
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertCommissairePriseur(CommissairePriseurDAO p)
        {
            int id = PersonneDAL.getMaxIdPersonne();
            
            string query = "INSERT INTO commissairepriseur VALUES (\"" + id +  "\",\"" + p.estVolontaireDAO + "\",\"" + p.formationDAO + "\",\"" + p.verifFormationDAO +"\");";
            
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerCommissairePriseur(int id)
        {
            string query = "DELETE FROM commissairepriseur WHERE fk_idPersonne = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdCommissairePriseur()
        {
            int maxIdCommissairePriseur = 0;
            string query = "SELECT MAX(fk_idPersonne) FROM commissairepriseur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdCommissairePriseur = reader.GetInt32(0);
                }
                else
                {
                    maxIdCommissairePriseur = 0;
                }
            }
            reader.Close();
            return maxIdCommissairePriseur;
        }

        public static CommissairePriseurDAO getCommissairePriseur(int idPersonneCommissairePriseur)
        {
            string query = "SELECT * FROM commissairepriseur WHERE fk_idPersonne =" + idPersonneCommissairePriseur + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CommissairePriseurDAO pers = new CommissairePriseurDAO(reader.GetInt32(0), reader.GetString(1), 
                reader.GetString(2),(DateTime)reader.GetDateTime(3), reader.GetString(4), 
                reader.GetString(5), reader.GetString(6),reader.GetInt32(7),reader.GetInt32(8),
                reader.GetString(9), reader.GetInt32(10));
            
            reader.Close();
            return pers;
        }
    }
}