using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class CategorieProduitDAL
    {
        public CategorieProduitDAL()
        { }

        public static ObservableCollection<CategorieProduitDAO> selectCategorieProduits()
        {
            ObservableCollection<CategorieProduitDAO> l = new ObservableCollection<CategorieProduitDAO>();
            string query = "SELECT * FROM CategorieProduit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategorieProduitDAO p = new CategorieProduitDAO(reader.GetInt32(0), reader.GetInt32(1));
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

        public static void updateCategorieProduit(CategorieProduitDAO p)
        {
            string query = "UPDATE CategorieProduit set idCategorieCP=\"" + p._idCategorieCPDAO +     
                             "\" where idProduitCP=" + p._idProduitCPDAO + ";";
            
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertCategorieProduit(CategorieProduitDAO p)
        {
            int id = getMaxIdCategorieProduit() + 1;
            
            string query = "INSERT INTO commissairepriseur VALUES (\"" + id + "\",\"" + p._idProduitCPDAO +"\");";
            
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerCategorieProduit(int idCategorie, int idProduit)
        {
            string query = "DELETE FROM CategorieProduit WHERE idCategorieCP AND idProduitCP = \"" + idCategorie + "\",\"" +idProduit + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdCategorieProduit()
        {
            int maxIdCategorieProduit = 0;
            string query = "SELECT MAX(idCategorieCP) AND MAX(idProduitCP) FROM CategorieProduit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdCategorieProduit = reader.GetInt32(0);
                }
                else
                {
                    maxIdCategorieProduit = 0;
                }
            }
            reader.Close();
            return maxIdCategorieProduit;
        }

        public static CategorieProduitDAO getCategorieProduit(int idCategorie, int idProduit)
        {
            string query = "SELECT * FROM CategorieProduit WHERE idCategorieCP AND idProduitCP =" + idCategorie + idProduit + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CategorieProduitDAO pers = new CategorieProduitDAO(reader.GetInt32(0), reader.GetInt32(1));
            
            reader.Close();
            return pers;
        }
    }
}
    