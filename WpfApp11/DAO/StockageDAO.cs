using System.Collections.ObjectModel;

namespace WpfApp11
{
    public class StockageDAO
    {
        public int idStockageDAO;
        public int idAdresseStockageDAO;

        public StockageDAO(int idStockageDao, int idAdresseStockageDAO)
        {
            idStockageDAO = idStockageDao;
            this.idAdresseStockageDAO = idAdresseStockageDAO;
        }
        public static ObservableCollection<StockageDAO>  listeStockages()
        {
            ObservableCollection<StockageDAO> l = StockageDAL.selectStockages();
            return l;
        }

        public static StockageDAO getStockage(int idStockage)
        {
            StockageDAO p = StockageDAL.getStockage(idStockage);
            return p;
        }

        public static void updateStockage(StockageDAO p)
        {
            StockageDAL.updateStockage(p);
        }

        public static void supprimerStockage(int id)
        {
            StockageDAL.supprimerStockage(id);
        }

        public static void insertStockage(StockageDAO p)
        {
            StockageDAL.insertStockage(p);
        }
    }
}