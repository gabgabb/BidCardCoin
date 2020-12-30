using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class CommissairePriseurORM
    {

        public static CommissairePriseurViewModel getCommissairePriseur(int idCommissairePriseur)
        {
            CommissairePriseurDAO cpDAO = CommissairePriseurDAO.getCommissairePriseur(idCommissairePriseur);


            CommissairePriseurViewModel cp = new CommissairePriseurViewModel(cpDAO.idPersonneCommissairePriseurDAO,
                cpDAO.nomPersonneDAO, cpDAO.prenomPersonneDAO, cpDAO.dateNaisPersonneDAO, cpDAO.emailDAO,
                cpDAO.passwordDAO, cpDAO.telephoneDAO, cpDAO.verifIdDAO, cpDAO.estVolontaireDAO,
                cpDAO.formationDAO, cpDAO.verifFormationDAO);
            return cp;
        }

        public static ObservableCollection<CommissairePriseurViewModel> listeCommissairePriseurs()
        {
            ObservableCollection<CommissairePriseurDAO> lDAO = CommissairePriseurDAO.listeCommissairePriseurs();
            ObservableCollection<CommissairePriseurViewModel> l = new ObservableCollection<CommissairePriseurViewModel>();

            ObservableCollection<PersonneViewModel> per = new ObservableCollection<PersonneViewModel>();

            foreach (CommissairePriseurDAO element in lDAO)
            {
                PersonneViewModel pe = new PersonneViewModel(element.idPersonneDAO, element.nomPersonneDAO, element.prenomPersonneDAO,
                    element.dateNaisPersonneDAO, element.emailDAO, element.passwordDAO, element.telephoneDAO, element.verifIdDAO);

                CommissairePriseurViewModel p = new CommissairePriseurViewModel(element.idPersonneCommissairePriseurDAO,
                    element.nomPersonneDAO, element.prenomPersonneDAO, element.dateNaisPersonneDAO, element.emailDAO,
                    element.passwordDAO, element.telephoneDAO, element.verifIdDAO, element.estVolontaireDAO,
                    element.formationDAO, element.verifFormationDAO);

                per.Add(pe);
                l.Add(p);
            }

            return l;
        }


        public static void updateCommissairePriseur(CommissairePriseurViewModel p)
        {
            CommissairePriseurDAO.updateCommissairePriseur(new CommissairePriseurDAO(
                p.idPersonneProperty, p.nomPersonneProperty, p.prenomPersonneProperty, p.DateNaisPersonneProperty,
                p.emailProperty, p.passwordProperty, p.telephoneProperty, p.verifIdProperty, p.estVolontaireProperty,
                p.formationProperty,
                p.verifFormationProperty));
        }

        public static void supprimerCommissairePriseur(int id)
        {
            CommissairePriseurDAO.supprimerCommissairePriseur(id);
            PersonneDAO.supprimerPersonne(id);
        }

        public static void insertCommissairePriseur(CommissairePriseurViewModel p)
        {
            PersonneDAO.insertPersonne(new PersonneDAO(p.idPersonneProperty, p.nomPersonneProperty,
             p.prenomPersonneProperty, p.DateNaisPersonneProperty, p.emailProperty, p.passwordProperty,
             p.telephoneProperty, p.verifIdProperty));

            CommissairePriseurDAO.insertCommissairePriseur(new CommissairePriseurDAO(p.idPersonneProperty,
                p.nomPersonneProperty, p.prenomPersonneProperty, p.DateNaisPersonneProperty,
                p.emailProperty, p.passwordProperty, p.telephoneProperty, p.verifIdProperty, p.estVolontaireProperty,
                p.formationProperty,
                p.verifFormationProperty));
        }
    }

}