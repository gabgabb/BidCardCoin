using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class AdresseORM
    {

        public static AdresseViewModel getAdresse(int idAdresse)
        {
            AdresseDAO aDAO = AdresseDAO.getAdresse(idAdresse);

            AdresseViewModel a = new AdresseViewModel(aDAO.idAdresseDAO, aDAO.numeroDAO, aDAO.rueDAO, aDAO.villeDAO,
                aDAO.codePostalDAO, aDAO.paysDAO);
            return a;
        }

        public static ObservableCollection<AdresseViewModel> listeAdresses()
        {
            ObservableCollection<AdresseDAO> lDAO = AdresseDAO.listeAdresses();
            ObservableCollection<AdresseViewModel> l = new ObservableCollection<AdresseViewModel>();
            foreach (AdresseDAO element in lDAO)
            {

                AdresseViewModel a = new AdresseViewModel(element.idAdresseDAO, element.numeroDAO, element.rueDAO,
                    element.villeDAO, element.codePostalDAO, element.paysDAO);
                l.Add(a);
            }

            return l;
        }


        public static void updateAdresse(AdresseViewModel a)
        {
            AdresseDAO.updateAdresse(new AdresseDAO(a.idAdresseProperty, a.numeroProperty, a.rueProperty,
                a.villeProperty, a.codePostalProperty, a.paysProperty));
        }

        public static void supprimerAdresse(int id)
        {
            AdresseDAO.supprimerAdresse(id);
        }

        public static void insertAdresse(AdresseViewModel a)
        {
            AdresseDAO.insertAdresse(new AdresseDAO(a.idAdresseProperty, a.numeroProperty, a.rueProperty,
                a.villeProperty, a.codePostalProperty, a.paysProperty));
        }
    }
}