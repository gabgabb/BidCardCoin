using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfApp11
{
    public class EvenementVenteDAO
    {
        public int idEvenementVenteDAO;
        public int estVolontaireEvenementVenteDAO;
        public string nomEvenementVenteDAO;
        public int idCommissairePriseurEvenementVenteDAO;
        public int idAdresseEvenementVenteDAO;

        public EvenementVenteDAO(int idEvenementVente, int estVolontaireEvenementVente, string nomEvenementVente,
            int idCommissairePriseurEvenementVenteDAO, int idAdresseEvenementVenteDAO)
        {
            this.idEvenementVenteDAO = idEvenementVente;
            this.estVolontaireEvenementVenteDAO = estVolontaireEvenementVente;
            this.nomEvenementVenteDAO = nomEvenementVente;
            this.idCommissairePriseurEvenementVenteDAO = idCommissairePriseurEvenementVenteDAO;

            this.idAdresseEvenementVenteDAO = idAdresseEvenementVenteDAO;
        }
    

    public static ObservableCollection<EvenementVenteDAO>  listeEvenementVentes()
        {
            ObservableCollection<EvenementVenteDAO> l = EvenementVenteDAL.selectEvenementVentes();
            return l;
        }

        public static EvenementVenteDAO getEvenementVente(int idEvenementVente)
        {
            EvenementVenteDAO p = EvenementVenteDAL.getEvenementVente(idEvenementVente);
            return p;
        }

        public static void updateEvenementVente(EvenementVenteDAO p)
        {
            EvenementVenteDAL.updateEvenementVente(p);
        }

        public static void supprimerEvenementVente(int id)
        {
            EvenementVenteDAL.supprimerEvenementVente(id);
        }

        public static void insertEvenementVente(EvenementVenteDAO p)
        {
            EvenementVenteDAL.insertEvenementVente(p);
        }
    }
}