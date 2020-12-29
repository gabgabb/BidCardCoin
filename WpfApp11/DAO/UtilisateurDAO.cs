using System;
using System.Collections.ObjectModel;

namespace WpfApp11
{
    public class UtilisateurDAO : PersonneDAO
    {
        public int idPersonneDAO;
        public string _ModePaiementDAO;
        public int verifSolvableDAO;
        public int estFrancaisDAO;

        public UtilisateurDAO(int idPersonneDao, string nomPersonneDao, string prenomPersonneDao,
            DateTime dateNaisPersonneDao, string emailDao, string passwordDao, string telephoneDao, int verifIdDao,
            string modePaiementDao, int verifSolvableDao, int estFrancaisDao) : base(idPersonneDao, nomPersonneDao,
            prenomPersonneDao, dateNaisPersonneDao, emailDao, passwordDao, telephoneDao, verifIdDao)
        {
            idPersonneDAO = idPersonneDao;
            _ModePaiementDAO = modePaiementDao;
            verifSolvableDAO = verifSolvableDao;
            estFrancaisDAO = estFrancaisDao;
        }

        public static ObservableCollection<UtilisateurDAO>  listeUtilisateurs()
        {
            ObservableCollection<UtilisateurDAO> l = UtilisateurDAL.selectUtilisateurs();
            return l;
        }
        
        public static UtilisateurDAO getUtilisateur(int idPersonne)
        {
            UtilisateurDAO p = UtilisateurDAL.getUtilisateur(idPersonne);
            return p;
        }

        public static void updateUtilisateur(UtilisateurDAO p)
        {
            
            UtilisateurDAL.updateUtilisateur(p);
        }

        public static void supprimerUtilisateur(int id)
        {
            UtilisateurDAL.supprimerUtilisateur(id);
        }

        public static void insertUtilisateur(UtilisateurDAO p)
        {
            UtilisateurDAL.insertUtilisateur(p);
        }
    }
}