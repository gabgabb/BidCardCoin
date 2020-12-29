using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class CategorieDAL
    {
         public CategorieDAL()
        { }

        public static ObservableCollection<CategorieDAO> selectCategories()
        {
            ObservableCollection<CategorieDAO> l = new ObservableCollection<CategorieDAO>();
            string query = "SELECT * FROM categorie;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategorieDAO p = new CategorieDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Categorie : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateCategorie(CategorieDAO p)
        {
            string query = "UPDATE categorie set nomCategorie=\"" + p.nomCategorieDAO + "\", descriptionCategorie=\"" + p.descriptionCategorieDAO  + "\" where idCategorie=" + p.idCategorieDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertCategorie(CategorieDAO p)
        {
            int id = getMaxIdCategorie() + 1;
            string query = "INSERT INTO categorie VALUES (\"" + id + "\",\"" + p.nomCategorieDAO + "\",\"" + p.descriptionCategorieDAO+ "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerCategorie(int id)
        {
            string query = "DELETE FROM categorie WHERE idCategorie = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdCategorie()
        {
            int maxIdCategorie = 0;
            string query = "SELECT MAX(idCategorie) FROM categorie;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdCategorie = reader.GetInt32(0);
                }
                else
                {
                    maxIdCategorie = 0;
                }
            }
            reader.Close();
            return maxIdCategorie;
        }

        public static CategorieDAO getCategorie(int idCategorie)
        {
            string query = "SELECT * FROM Categorie WHERE id=" + idCategorie + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CategorieDAO pers = new CategorieDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            reader.Close();
            return pers;
        }
    }
}