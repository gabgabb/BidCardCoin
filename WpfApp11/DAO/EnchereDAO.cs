using System;
using System.Collections.ObjectModel;

namespace WpfApp11
{
    public class EnchereDAO
    {
        public int idEnchereDAO;
        public double prixEnchereDAO;
        public DateTime dateEnchereDAO;
        public int adjugeDAO;
        public int idUtilisateurEnchereDAO;
        public int idLotEnchereDAO;
        public int idCommissairePriseurEnchereDAO;
        public int idOrdreAchatEnchereDAO;

        public EnchereDAO(int idEnchereDao,double prixEnchereDAO, DateTime dateEnchereDao, int adjugeDao, int idCommissairePriseurEnchereDao, int idUtilisateurEnchereDao, int idLotEnchereDao, int idOrdreAchatEnchereDAO)
        {
            idEnchereDAO = idEnchereDao;
            this.prixEnchereDAO = prixEnchereDAO;
            dateEnchereDAO = dateEnchereDao;
            adjugeDAO = adjugeDao;
            idUtilisateurEnchereDAO = idUtilisateurEnchereDao;
            idLotEnchereDAO = idLotEnchereDao;
            idCommissairePriseurEnchereDAO = idCommissairePriseurEnchereDao;
            this.idOrdreAchatEnchereDAO = idOrdreAchatEnchereDAO;
        }
        
        public static ObservableCollection<EnchereDAO>  listeEncheres()
        {
            ObservableCollection<EnchereDAO> l = EnchereDAL.selectEncheres();
            return l;
        }

        public static EnchereDAO getEnchere(int idEnchere)
        {
            EnchereDAO p = EnchereDAL.getEnchere(idEnchere);
            return p;
        }

        public static void updateEnchere(EnchereDAO p)
        {
            EnchereDAL.updateEnchere(p);
        }

        public static void supprimerEnchere(int id)
        {
            EnchereDAL.supprimerEnchere(id);
        }

        public static void insertEnchere(EnchereDAO p)
        {
            EnchereDAL.insertEnchere(p);
        }
    }
}