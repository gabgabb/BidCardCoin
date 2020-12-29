using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class ProduitDAL
    {
        public ProduitDAL()
        { }

        public static ObservableCollection<ProduitDAO> selectProduits()
        {
            ObservableCollection<ProduitDAO> l = new ObservableCollection<ProduitDAO>();
            string query = "SELECT * FROM produit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProduitDAO p = new ProduitDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), 
                        reader.GetDouble(3), reader.GetDouble(4), reader.GetInt32(5), 
                        reader.GetInt32(6), reader.GetDouble(7), reader.GetInt32(8), 
                        reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Produit : {0}", e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateProduit(ProduitDAO p)
        {
            string query = "UPDATE produit set nomProduit=\"" + p.nomProduitDAO + "\", descriptionProduit=\"" + p.descriptionProduitDAO + "\", prixReserveDAO=\"" 
                           + p.prixReserveDAO + "\", prixDepartDAO=\"" + p.prixDepartDAO + "\", estVenduDAO=\"" + p.estVenduDAO + "\", enStockDAO=\"" 
                           + p.enStockDAO + "\", prixVenteDAO=\"" + p.prixVenteDAO + "\", nbInvenduDAO=\"" + p.nbInvenduDAO + "\", idUtilisateurProduitDAO=\"" 
                           + p.idUtilisateurProduitDAO + "\", idLotProduitDAO=\"" 
                           + p.idLotProduitDAO + "\", idStockageProduit=\"" + p.idStockageProduitDAO+ "\" where idProduit=" + p.idProduitDAO + ";";
            
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertProduit(ProduitDAO p)
        {
            int id = getMaxIdProduit() + 1;
           
            string query = "INSERT INTO produit VALUES (\"" + id + "\",\"" + p.nomProduitDAO + "\",\"" + p.descriptionProduitDAO + "\", \"" + p.prixReserveDAO + "\", \"" + p.prixDepartDAO + "\",\"" + p.estVenduDAO + "\",\"" + p.enStockDAO + "\",\"" + p.prixVenteDAO + "\",\"" + p.nbInvenduDAO + "\",\"" + p.idUtilisateurProduitDAO + "\",\"" + p.idLotProduitDAO+ "\",\"" + p.idStockageProduitDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerProduit(int id)
        {
            string query = "DELETE FROM produit WHERE idProduit = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdProduit()
        {
            int maxIdProduit = 0;
            string query = "SELECT MAX(idProduit) FROM produit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdProduit = reader.GetInt32(0);
                }
                else
                {
                    maxIdProduit = 0;
                }
            }
            reader.Close();
            return maxIdProduit;
        }

        public static ProduitDAO getProduit(int idProduit)
        {
            string query = "SELECT * FROM produit WHERE id=" + idProduit + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ProduitDAO pers = new ProduitDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), 
                reader.GetDouble(3), reader.GetDouble(4), reader.GetInt32(5), 
                reader.GetInt32(6), reader.GetDouble(7), reader.GetInt32(8), 
                reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11));
            reader.Close();
            return pers;
        }
    }
}
