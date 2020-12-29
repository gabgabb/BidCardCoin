using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class ProduitVenteDAL
    {
        public ProduitVenteDAL()
        { }

        public static ObservableCollection<ProduitVenteDAO> selectProduitVentes()
        {
            ObservableCollection<ProduitVenteDAO> l = new ObservableCollection<ProduitVenteDAO>();
            string query = "SELECT * FROM ProduitVente;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProduitVenteDAO p = new ProduitVenteDAO(reader.GetInt32(0), reader.GetInt32(1));
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

        public static void updateProduitVente(ProduitVenteDAO p)
        {
            string query = "UPDATE ProduitVente set idVentePV=\"" + p.idVenteDAOPV +     
                             "\" where idProduitCP=" + p.idProduitPVDAO + ";";
            
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertProduitVente(ProduitVenteDAO p)
        {
            int id = getMaxIdProduitVente() + 1;
            
            string query = "INSERT INTO ProduitVente VALUES (\"" + id + "\",\"" + p.idVenteDAOPV +"\");";
            
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerProduitVente(int idProduit, int idVente)
        {
            string query = "DELETE FROM ProduitVente WHERE idProduitPV AND idVentePV = \"" + idProduit + "\",\"" + idVente + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdProduitVente()
        {
            int maxIdProduitVente = 0;
            string query = "SELECT MAX(idProduitPV) AND MAX(idVentePV) FROM ProduitVente;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdProduitVente = reader.GetInt32(0);
                }
                else
                {
                    maxIdProduitVente = 0;
                }
            }
            reader.Close();
            return maxIdProduitVente;
        }

        public static ProduitVenteDAO getProduitVente(int idProduit, int idVente)
        {
            string query = "SELECT * FROM ProduitVente WHERE idProduitPV AND idVentePV =" + idProduit + idVente + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ProduitVenteDAO pers = new ProduitVenteDAO(reader.GetInt32(0), reader.GetInt32(1));
            
            reader.Close();
            return pers;
        }
    }
}