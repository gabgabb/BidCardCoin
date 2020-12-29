using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class LotORM
    {

        public static LotViewModel getLot(int idLot)
        {
            LotDAO lDAO = LotDAO.getLot(idLot);

            LotViewModel p = new LotViewModel(lDAO.idLotDAO, lDAO.nomLotDAO, lDAO.descriptionLotDAO);
            return p;
        }

        public static ObservableCollection<LotViewModel> listeLots()
        {
            ObservableCollection<LotDAO> lDAO = LotDAO.listeLots();
            ObservableCollection<LotViewModel> l = new ObservableCollection<LotViewModel>();
            foreach (LotDAO element in lDAO)
            {
                LotViewModel p = new LotViewModel(element.idLotDAO, element.nomLotDAO, element.descriptionLotDAO);
                l.Add(p);
            }

            return l;
        }


        public static void updateLot(LotViewModel l)
        {
            LotDAO.updateLot(new LotDAO(l.idLotProperty, l.nomLotProperty, l.descriptionLotProperty));
        }

        public static void supprimerLot(int id)
        {
            LotDAO.supprimerLot(id);
        }

        public static void insertLot(LotViewModel l)
        {
            LotDAO.insertLot(new LotDAO(l.idLotProperty, l.nomLotProperty, l.descriptionLotProperty));
        }
    }
}