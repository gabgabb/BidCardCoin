using System;
using System.Collections.ObjectModel;

namespace WpfApp11
{
    public class CommissairePriseurDAO : PersonneDAO
    {
        public int idPersonneCommissairePriseurDAO;
        public int estVolontaireDAO;
        public string formationDAO;
        public int verifFormationDAO;

        public CommissairePriseurDAO(int idPersonneDao, string nomPersonneDao, string prenomPersonneDao,
            DateTime dateNaisPersonneDao, string emailDao, string passwordDao, string telephoneDao, int verifIdDao,
            int estVolontaireDao, string formationDao, int verifFormationDao) : base(idPersonneDao, nomPersonneDao,
            prenomPersonneDao, dateNaisPersonneDao, emailDao, passwordDao, telephoneDao, verifIdDao)
        {
            idPersonneCommissairePriseurDAO = idPersonneDao;
            estVolontaireDAO = estVolontaireDao;
            formationDAO = formationDao;
            verifFormationDAO = verifFormationDao;
        }


        public static ObservableCollection<CommissairePriseurDAO> listeCommissairePriseurs()
        {
            ObservableCollection<CommissairePriseurDAO> l = CommissairePriseurDAL.selectCommissairePriseurs();
            return l;
        }

        public static CommissairePriseurDAO getCommissairePriseur(int idPersonneCommissairePriseur)
        {
            CommissairePriseurDAO p = CommissairePriseurDAL.getCommissairePriseur(idPersonneCommissairePriseur);
            return p;
        }

        public static void updateCommissairePriseur(CommissairePriseurDAO p)
        {
            CommissairePriseurDAL.updateCommissairePriseur(p);
        }

        public static void supprimerCommissairePriseur(int id)
        {
            CommissairePriseurDAL.supprimerCommissairePriseur(id);
        }

        public static void insertCommissairePriseur(CommissairePriseurDAO p)
        {
            CommissairePriseurDAL.insertCommissairePriseur(p);
        }
    }
}