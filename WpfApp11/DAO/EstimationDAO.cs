using System;
using System.Collections.ObjectModel;

namespace WpfApp11
{
    public class EstimationDAO
    {
        public int idProduitEstimationDAO;
        public int idCommissairePriseurEstimationDAO;
        public DateTime DateEstimationDAO;
        public double prixEstimeDAO;

        public EstimationDAO(int idProduitEstimationDao, int idCommissairePriseurEstimationDao, DateTime dateEstimationDao, double prixEstimeDao)
        {
           
            DateEstimationDAO = dateEstimationDao;
            prixEstimeDAO = prixEstimeDao;
            idProduitEstimationDAO = idProduitEstimationDao;
            idCommissairePriseurEstimationDAO = idCommissairePriseurEstimationDao;
        }
        
        public static ObservableCollection<EstimationDAO>  listeEstimations()
        {
            ObservableCollection<EstimationDAO> l = EstimationDAL.selectEstimations();
            return l;
        }

        public static EstimationDAO getEstimation(int idProduitEstimation, int idCommissairePriseurEstimationDAO)
        {
            EstimationDAO p = EstimationDAL.getEstimation(idProduitEstimation,idCommissairePriseurEstimationDAO);
            return p;
        }

        public static void updateEstimation(EstimationDAO p)
        {
            EstimationDAL.updateEstimation(p);
        }

        public static void supprimerEstimation(int idProduitEstimation, int idCommissairePriseurEstimationDAO)
        {
            EstimationDAL.supprimerEstimation(idProduitEstimation,idCommissairePriseurEstimationDAO);
        }

        public static void insertEstimation(EstimationDAO p)
        {
            EstimationDAL.insertEstimation(p);
        }
    }
}