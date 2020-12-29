using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class ProduitDAO
    {
        public int idProduitDAO;
        public string nomProduitDAO;
        public string descriptionProduitDAO;
        public double prixReserveDAO;
        public double prixDepartDAO;
        public int estVenduDAO;
        public int enStockDAO;
        public double prixVenteDAO;
        public int nbInvenduDAO;
        public int idUtilisateurProduitDAO;
        public int idLotProduitDAO;
        public int idStockageProduitDAO;

        public ProduitDAO(int idProduitDao, string nomProduitDao, string descriptionDao, double prixReserveDao, double prixDepartDao, int estVenduDao, int enstockDao, double prixVenteDao, int nbInvenduDao, int idUtilisateurProduitDao, int idLotProduitDao, int idStockageProduitDao)
        {
            idProduitDAO = idProduitDao;
            nomProduitDAO = nomProduitDao;
            descriptionProduitDAO = descriptionDao;
            prixReserveDAO = prixReserveDao;
            prixDepartDAO = prixDepartDao;
            estVenduDAO = estVenduDao;
            enStockDAO = enstockDao;
            prixVenteDAO = prixVenteDao;
            nbInvenduDAO = nbInvenduDao;
            idUtilisateurProduitDAO = idUtilisateurProduitDao;
            idLotProduitDAO = idLotProduitDao;
            idStockageProduitDAO = idStockageProduitDao;
        }

        public static ObservableCollection<ProduitDAO> listeProduits()
        {
            ObservableCollection<ProduitDAO> l = ProduitDAL.selectProduits();
            return l;
        }

        public static ProduitDAO getProduit(int idProduit)
        {
            ProduitDAO p = ProduitDAL.getProduit(idProduit);
            return p;
        }

        public static void updateProduit(ProduitDAO p)
        {
            ProduitDAL.updateProduit(p);
        }

        public static void supprimerProduit(int id)
        {
            ProduitDAL.supprimerProduit(id);
        }

        public static void insertProduit(ProduitDAO p)
        {
            ProduitDAL.insertProduit(p);
        }
    }
}
