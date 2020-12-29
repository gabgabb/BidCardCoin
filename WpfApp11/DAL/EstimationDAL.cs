using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class EstimationDAL
    {
        public EstimationDAL()
        { }

        public static ObservableCollection<EstimationDAO> selectEstimations()
        {
            ObservableCollection<EstimationDAO> l = new ObservableCollection<EstimationDAO>();
            string query = "SELECT * FROM estimation;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
           try
           {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EstimationDAO p = new EstimationDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetDouble(3));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Estimation : {0}",e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateEstimation(EstimationDAO p)
        {
            string query = "UPDATE estimation set dateEstimation=\"" + p.DateEstimationDAO + "\", prixEstime=\"" + p.prixEstimeDAO  + "\" where idProduitEstimation=" + p.idProduitEstimationDAO +"\" and where idCommissairePriseurEstimation=" + p.idCommissairePriseurEstimationDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEstimation(EstimationDAO p)
        {
            int id = getMaxIdEstimation() + 1;
            String dateEstimation= p.DateEstimationDAO.ToString("yyyy-MM-dd");
            string query = "INSERT INTO estimation VALUES (\"" + id + "\",\"" + dateEstimation + "\",\"" + p.prixEstimeDAO+ "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEstimation(int idP, int idCP)
        {
            string query = "DELETE FROM Estimation WHERE idProduitEstimation AND idCommissairePriseurEstimation = \"" + idP + "\",\""+ idCP + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdEstimation()
        {
            int maxIdEstimation = 0;
            string query = "SELECT MAX(idProduitEstimation) AND MAX(idCommissairePriseurEstimation) FROM estimation;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdEstimation = reader.GetInt32(0);
                }
                else
                {
                    maxIdEstimation = 0;
                }
            }
            reader.Close();
            return maxIdEstimation;
        }

        public static EstimationDAO getEstimation(int idP, int idCp)
        {
            string query = "SELECT * FROM estimation WHERE id=" + idP + idCp+ ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EstimationDAO pers = new EstimationDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetDouble(3));
            reader.Close();
            return pers;
        }
    }
}