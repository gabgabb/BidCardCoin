using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class StockageORM
    {

        public static StockageViewModel getStockage(int idStockage)
        {
            StockageDAO sDAO = StockageDAO.getStockage(idStockage);

            int idAdresse = sDAO.idAdresseStockageDAO;
            AdresseViewModel a = AdresseORM.getAdresse(idAdresse);

            StockageViewModel s = new StockageViewModel(sDAO.idStockageDAO, a);
            return s;
        }

        public static ObservableCollection<StockageViewModel> listeStockages()
        {
            ObservableCollection<StockageDAO> lDAO = StockageDAO.listeStockages();
            ObservableCollection<StockageViewModel> l = new ObservableCollection<StockageViewModel>();
            foreach (StockageDAO element in lDAO)
            {
                int idAdresse = element.idAdresseStockageDAO;
                AdresseViewModel a = AdresseORM.getAdresse(idAdresse);

                StockageViewModel s = new StockageViewModel(element.idAdresseStockageDAO, a);
                l.Add(s);
            }

            return l;
        }


        public static void updateStockage(StockageViewModel s)
        {
            StockageDAO.updateStockage(new StockageDAO(s.idStockageProperty,
                s.idAdresseStockageProperty.idAdresseProperty));
        }

        public static void supprimerStockage(int id)
        {
            StockageDAO.supprimerStockage(id);
        }

        public static void insertStockage(StockageViewModel s)
        {
            StockageDAO.insertStockage(new StockageDAO(s.idStockageProperty,
                s.idAdresseStockageProperty.idAdresseProperty));
        }
    }
}