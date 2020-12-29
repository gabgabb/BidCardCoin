using System;
using System.Collections.ObjectModel;

namespace WpfApp11
{
    public class OrdreAchatDAO
    {
        public int idOrdreAchatDAO;
        public double prixMaxDAO;
        public DateTime DateOrdreDAO;
        public int idUtilisateurOrdreDAO;
        public int idProduitOrdreDAO;

        public OrdreAchatDAO(int idOrdreAchatDao, double prixMaxDao, DateTime dateOrdreDao, int idUtilisateurOrdreDao, int idProduitOrdre)
        {
            idOrdreAchatDAO = idOrdreAchatDao;
            prixMaxDAO = prixMaxDao;
            DateOrdreDAO = dateOrdreDao;
            idUtilisateurOrdreDAO = idUtilisateurOrdreDao;
            this.idProduitOrdreDAO = idProduitOrdre;
        }
        public static ObservableCollection<OrdreAchatDAO>  listeOrdreAchats()
        {
            ObservableCollection<OrdreAchatDAO> l = OrdreAchatDAL.selectOrdreAchats();
            return l;
        }

        public static OrdreAchatDAO getOrdreAchat(int idOrdreAchat)
        {
            OrdreAchatDAO p = OrdreAchatDAL.getOrdreAchat(idOrdreAchat);
            return p;
        }

        public static void updateOrdreAchat(OrdreAchatDAO p)
        {
            OrdreAchatDAL.updateOrdreAchat(p);
        }

        public static void supprimerOrdreAchat(int id)
        {
            OrdreAchatDAL.supprimerOrdreAchat(id);
        }

        public static void insertOrdreAchat(OrdreAchatDAO p)
        {
            OrdreAchatDAL.insertOrdreAchat(p);
        }
    }
}