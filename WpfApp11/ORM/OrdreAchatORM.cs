using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class OrdreAchatORM
    {

        public static OrdreAchatViewModel getOrdreAchat(int idOrdreAchat)
        {
            OrdreAchatDAO pDAO = OrdreAchatDAO.getOrdreAchat(idOrdreAchat);

            int idProduit = pDAO.idProduitOrdreDAO;
            ProduitViewModel pro = ProduitORM.getProduit(idProduit);

            int idUtilisateur = pDAO.idUtilisateurOrdreDAO;
            UtilisateurViewModel u = UtilisateurORM.getUtilisateur(idUtilisateur);


            OrdreAchatViewModel p =
                new OrdreAchatViewModel(pDAO.idOrdreAchatDAO, pDAO.prixMaxDAO, pDAO.DateOrdreDAO, u, pro);
            return p;
        }

        public static ObservableCollection<OrdreAchatViewModel> listeOrdreAchats()
        {
            ObservableCollection<OrdreAchatDAO> lDAO = OrdreAchatDAO.listeOrdreAchats();
            ObservableCollection<OrdreAchatViewModel> l = new ObservableCollection<OrdreAchatViewModel>();
            foreach (OrdreAchatDAO element in lDAO)
            {
                int idProduit = element.idProduitOrdreDAO;
                ProduitViewModel pro = ProduitORM.getProduit(idProduit);

                int idUtilisateur = element.idUtilisateurOrdreDAO;
                UtilisateurViewModel u = UtilisateurORM.getUtilisateur(idUtilisateur);

                OrdreAchatViewModel p = new OrdreAchatViewModel(element.idOrdreAchatDAO, element.prixMaxDAO,
                    element.DateOrdreDAO, u, pro);
                l.Add(p);
            }

            return l;
        }


        public static void updateOrdreAchat(OrdreAchatViewModel p)
        {
            OrdreAchatDAO.updateOrdreAchat(new OrdreAchatDAO(p.idOrdreAchatProperty, p.prixMaxProperty,
                p.dateOrdreProperty, p.idUtilisateurOrdreProperty.idPersonneUtilisateurProperty,
                p.idProduitOrdreProperty.idProduitProperty));
        }


        public static void supprimerOrdreAchat(int id)
        {
            OrdreAchatDAO.supprimerOrdreAchat(id);
        }

        public static void insertOrdreAchat(OrdreAchatViewModel p)
        {
            OrdreAchatDAO.insertOrdreAchat(new OrdreAchatDAO(p.idOrdreAchatProperty, p.prixMaxProperty,
                p.dateOrdreProperty, p.idUtilisateurOrdreProperty.idPersonneUtilisateurProperty,
                p.idProduitOrdreProperty.idProduitProperty));
        }

    }
}