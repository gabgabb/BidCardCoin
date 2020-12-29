using System.Collections.ObjectModel;

namespace WpfApp11
{
    public class CategorieProduitDAO
    {
        public int _idCategorieCPDAO;
        public int _idProduitCPDAO;

        public CategorieProduitDAO(int idCategorieCp, int idProduitCp)
        {
            _idCategorieCPDAO = idCategorieCp;
            _idProduitCPDAO = idProduitCp;
        }
        
        public static ObservableCollection<CategorieProduitDAO> listeCategorieProduits()
        {
            ObservableCollection<CategorieProduitDAO> l = CategorieProduitDAL.selectCategorieProduits();
            return l;
        }

        public static CategorieProduitDAO getCategorieProduit(int idCategorie, int idProduit)
        {
            CategorieProduitDAO p = CategorieProduitDAL.getCategorieProduit(idCategorie, idProduit);
            return p;
        }

        public static void updateCategorieProduit(CategorieProduitDAO p)
        {
            CategorieProduitDAL.updateCategorieProduit(p);
        }

        public static void supprimerCategorieProduit(int id1, int id2)
        {
            CategorieProduitDAL.supprimerCategorieProduit(id1, id2);
        }

        public static void insertCategorieProduit(CategorieProduitDAO p)
        {
            CategorieProduitDAL.insertCategorieProduit(p);
        }
    }
}