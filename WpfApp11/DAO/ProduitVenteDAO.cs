using System.Collections.ObjectModel;

namespace WpfApp11
{
    public class ProduitVenteDAO
    {
        public int idProduitPVDAO;
        public int idVenteDAOPV;

        public ProduitVenteDAO(int idProduitPvdao, int idVenteDaopv)
        {
            idProduitPVDAO = idProduitPvdao;
            idVenteDAOPV = idVenteDaopv;
        }
        
        public static ObservableCollection<ProduitVenteDAO> listeProduitVentes()
        {
            ObservableCollection<ProduitVenteDAO> l = ProduitVenteDAL.selectProduitVentes();
            return l;
        }

        public static ProduitVenteDAO getProduitVente(int idProduit, int idVente)
        {
            ProduitVenteDAO p = ProduitVenteDAL.getProduitVente(idProduit,idVente);
            return p;
        }

        public static void updateProduitVente(ProduitVenteDAO p)
        {
            ProduitVenteDAL.updateProduitVente(p);
        }

        public static void supprimerProduitVente(int idProduit, int idVente)
        {
            ProduitVenteDAL.supprimerProduitVente(idProduit,idVente);
        }

        public static void insertProduitVente(ProduitVenteDAO p)
        {
            ProduitVenteDAL.insertProduitVente(p);
        }
    }
}