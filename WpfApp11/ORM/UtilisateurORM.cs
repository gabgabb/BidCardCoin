using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class UtilisateurORM
    {

        public static UtilisateurViewModel getUtilisateur(int idUtilisateur)
        {
            UtilisateurDAO pDAO = UtilisateurDAO.getUtilisateur(idUtilisateur);
            
            UtilisateurViewModel p = new UtilisateurViewModel(pDAO.idPersonneDAO, pDAO.nomPersonneDAO, pDAO.prenomPersonneDAO,
                pDAO.dateNaisPersonneDAO, pDAO.emailDAO, pDAO.passwordDAO, pDAO.telephoneDAO, pDAO.verifIdDAO, pDAO._ModePaiementDAO,
                pDAO.estFrancaisDAO, pDAO.verifSolvableDAO);
            return p;
        }

        public static ObservableCollection<UtilisateurViewModel> listeUtilisateurs()
        {
            ObservableCollection<UtilisateurDAO> lDAO = UtilisateurDAO.listeUtilisateurs();

            ObservableCollection<UtilisateurViewModel> l = new ObservableCollection<UtilisateurViewModel>();
            ObservableCollection<PersonneViewModel> per = new ObservableCollection<PersonneViewModel>();
            
            foreach (UtilisateurDAO element in lDAO)
            {
                PersonneViewModel pe = new PersonneViewModel(element.idPersonneDAO, element.nomPersonneDAO, element.prenomPersonneDAO,
                    element.dateNaisPersonneDAO, element.emailDAO, element.passwordDAO, element.telephoneDAO, element.verifIdDAO);
                
                UtilisateurViewModel p = new UtilisateurViewModel(element.idPersonneDAO, element.nomPersonneDAO, element.prenomPersonneDAO,
                    element.dateNaisPersonneDAO, element.emailDAO, element.passwordDAO, element.telephoneDAO, element.verifIdDAO, element._ModePaiementDAO,
                    element.estFrancaisDAO, element.verifSolvableDAO);
                
                per.Add(pe);
                l.Add(p);
                
            }
            return l;
        }

        public static void updateUtilisateur(UtilisateurViewModel p)
        {
            
            UtilisateurDAO.updateUtilisateur(new UtilisateurDAO(p.idPersonneProperty, p.nomPersonneProperty,
                p.prenomPersonneProperty, p.DateNaisPersonneProperty, p.emailProperty, p.passwordProperty,
                p.telephoneProperty, p.verifIdProperty, p._ModePaiementDAOProperty, p.estFrancaisProperty, p.verifSolvableProperty));
        }

        public static void supprimerUtilisateur(int id)
        {
            UtilisateurDAO.supprimerUtilisateur(id);
            PersonneDAO.supprimerPersonne(id);
        }

        public static void insertUtilisateur(UtilisateurViewModel p)
        {
            
            PersonneDAO.insertPersonne(new PersonneDAO(p.idPersonneProperty, p.nomPersonneProperty,
                p.prenomPersonneProperty, p.DateNaisPersonneProperty, p.emailProperty, p.passwordProperty,
                p.telephoneProperty, p.verifIdProperty));
            
            UtilisateurDAO.insertUtilisateur(new UtilisateurDAO(p.idPersonneProperty, p.nomPersonneProperty,
                p.prenomPersonneProperty, p.DateNaisPersonneProperty, p.emailProperty, p.passwordProperty,
                p.telephoneProperty, p.verifIdProperty, p._ModePaiementDAOProperty, p.verifSolvableProperty, p.estFrancaisProperty));
        }
    }
}