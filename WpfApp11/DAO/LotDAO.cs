using System.Collections.ObjectModel;

namespace WpfApp11
{
    public class LotDAO
    {
        public int idLotDAO;
        public string nomLotDAO;
        public string descriptionLotDAO;

        public LotDAO(int idLotDao, string nomLotDao, string descriptionDao)
        {
            idLotDAO = idLotDao;
            nomLotDAO = nomLotDao;
            descriptionLotDAO = descriptionDao;
        }
        
        public static ObservableCollection<LotDAO>  listeLots()
        {
            ObservableCollection<LotDAO> l = LotDAL.selectLots();
            return l;
        }

        public static LotDAO getLot(int idLot)
        {
            LotDAO p = LotDAL.getLot(idLot);
            return p;
        }

        public static void updateLot(LotDAO p)
        {
            LotDAL.updateLot(p);
        }

        public static void supprimerLot(int id)
        {
            LotDAL.supprimerLot(id);
        }

        public static void insertLot(LotDAO p)
        {
            LotDAL.insertLot(p);
        }
    }
}