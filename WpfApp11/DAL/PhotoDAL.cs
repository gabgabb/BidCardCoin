using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class PhotoDAL
    {
        public PhotoDAL()
        { }

        public static ObservableCollection<PhotoDAO> selectPhotos()
        {
            ObservableCollection<PhotoDAO> l = new ObservableCollection<PhotoDAO>();
            string query = "SELECT * FROM photo;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PhotoDAO p = new PhotoDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),reader.GetInt32(3));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Photo : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updatePhoto(PhotoDAO p)
        {
            string query = "UPDATE photo set nomPhoto=\"" + p.nomPhotoDAO  + "\", lienPhoto=\"" + p.lienPhotoDAO  +  "\", idProduit=\"" + p.idProduitDAO + "\" where idPhoto=" + p.idPhotoDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPhoto(PhotoDAO p)
        {
            int id = getMaxIdPhoto() + 1;
            
            string query = "INSERT INTO photo VALUES (\"" + id + "\",\"" + p.nomPhotoDAO + "\",\"" + p.lienPhotoDAO+  "\",\"" + p.idProduitDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerPhoto(int id)
        {
            string query = "DELETE FROM photo WHERE idPhoto = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdPhoto()
        {
            int maxIdPhoto = 0;
            string query = "SELECT MAX(idPhoto) FROM photo;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdPhoto = reader.GetInt32(0);
                }
                else
                {
                    maxIdPhoto = 0;
                }
            }
            reader.Close();
            return maxIdPhoto;
        }

        public static PhotoDAO getPhoto(int idPhoto)
        {
            string query = "SELECT * FROM photo WHERE id=" + idPhoto + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PhotoDAO pers = new PhotoDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),reader.GetInt32(3));
            reader.Close();
            return pers;
        }
    }
}