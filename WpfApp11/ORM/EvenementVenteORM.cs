using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class EvenementVenteORM
    {

        public static EvenementVenteViewModel getEvenementVente(int idEvenementVente)
        {
            EvenementVenteDAO pDAO = EvenementVenteDAO.getEvenementVente(idEvenementVente);

            int idCommissairePriseur = pDAO.idCommissairePriseurEvenementVenteDAO;
            CommissairePriseurViewModel cp = CommissairePriseurORM.getCommissairePriseur(idCommissairePriseur);

            int idAdresse = pDAO.idAdresseEvenementVenteDAO;
            AdresseViewModel a = AdresseORM.getAdresse(idAdresse);


            EvenementVenteViewModel p = new EvenementVenteViewModel(pDAO.idEvenementVenteDAO,
                pDAO.estVolontaireEvenementVenteDAO, pDAO.nomEvenementVenteDAO, cp, a);
            return p;
        }

        public static ObservableCollection<EvenementVenteViewModel> listeEvenementVentes()
        {
            ObservableCollection<EvenementVenteDAO> lDAO = EvenementVenteDAO.listeEvenementVentes();
            ObservableCollection<EvenementVenteViewModel> l = new ObservableCollection<EvenementVenteViewModel>();
            foreach (EvenementVenteDAO element in lDAO)
            {
                int idCommissairePriseur = element.idCommissairePriseurEvenementVenteDAO;
                CommissairePriseurViewModel cp = CommissairePriseurORM.getCommissairePriseur(idCommissairePriseur);

                int idAdresse = element.idAdresseEvenementVenteDAO;
                AdresseViewModel a = AdresseORM.getAdresse(idAdresse);

                EvenementVenteViewModel p = new EvenementVenteViewModel(element.idEvenementVenteDAO,
                    element.estVolontaireEvenementVenteDAO, element.nomEvenementVenteDAO, cp, a);
                l.Add(p);
            }

            return l;
        }


        public static void updateEvenementVente(EvenementVenteViewModel p)
        {
            EvenementVenteDAO.updateEvenementVente(new EvenementVenteDAO(p.idEvenementVenteProperty,
                p.estVolontaireEvenementVenteProperty, p.nomEvenementVenteProperty,
                p.idCommissairePriseurEvenementVenteProperty.idPersonneProperty,
                p.idAdresseEvenementVenteProperty.idAdresseProperty));
        }

        public static void supprimerEvenementVente(int id)
        {
            EvenementVenteDAO.supprimerEvenementVente(id);
        }

        public static void insertEvenementVente(EvenementVenteViewModel p)
        {
            EvenementVenteDAO.insertEvenementVente(new EvenementVenteDAO(p.idEvenementVenteProperty,
                p.estVolontaireEvenementVenteProperty, p.nomEvenementVenteProperty,
                p.idCommissairePriseurEvenementVenteProperty.idPersonneProperty,
                p.idAdresseEvenementVenteProperty.idAdresseProperty));
        }
    }
}