using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class PersonneORM
    {

        public static PersonneViewModel getPersonne(int idPersonne)
        {
            PersonneDAO pDAO = PersonneDAO.getPersonne(idPersonne);

            PersonneViewModel p = new PersonneViewModel(pDAO.idPersonneDAO, pDAO.nomPersonneDAO, pDAO.prenomPersonneDAO,
                pDAO.dateNaisPersonneDAO, pDAO.emailDAO, pDAO.passwordDAO, pDAO.telephoneDAO,
                pDAO.verifIdDAO);
            return p;
        }

        public static ObservableCollection<PersonneViewModel> listePersonnes()
        {
            ObservableCollection<PersonneDAO> lDAO = PersonneDAO.listePersonnes();
            ObservableCollection<PersonneViewModel> l = new ObservableCollection<PersonneViewModel>();
            foreach (PersonneDAO element in lDAO)
            {

                PersonneViewModel p = new PersonneViewModel(element.idPersonneDAO, element.nomPersonneDAO,
                    element.prenomPersonneDAO, element.dateNaisPersonneDAO, element.emailDAO, element.passwordDAO,
                    element.telephoneDAO, element.verifIdDAO);
                l.Add(p);
            }

            return l;
        }


        public static void updatePersonne(PersonneViewModel p)
        {
            PersonneDAO.updatePersonne(new PersonneDAO(p.idPersonneProperty, p.nomPersonneProperty,
                p.prenomPersonneProperty, p.DateNaisPersonneProperty, p.emailProperty, p.passwordProperty,
                p.telephoneProperty, p.verifIdProperty));
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAO.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneViewModel p)
        {
            PersonneDAO.insertPersonne(new PersonneDAO(p.idPersonneProperty, p.nomPersonneProperty,
                p.prenomPersonneProperty, p.DateNaisPersonneProperty, p.emailProperty, p.passwordProperty,
                p.telephoneProperty, p.verifIdProperty));
        }
    }
}
