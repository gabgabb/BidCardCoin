using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class EnchereORM
    {

        public static EnchereViewModel getEnchere(int idEnchere)
        {
            EnchereDAO eDAO = EnchereDAO.getEnchere(idEnchere);

            int idUtilisateur = eDAO.idUtilisateurEnchereDAO;
            UtilisateurViewModel u = UtilisateurORM.getUtilisateur(idUtilisateur);

            int idCommissairePriseur = eDAO.idCommissairePriseurEnchereDAO;
            CommissairePriseurViewModel cp = CommissairePriseurORM.getCommissairePriseur(idCommissairePriseur);

            int idlotEnchere = eDAO.idLotEnchereDAO;
            LotViewModel l = LotORM.getLot(idlotEnchere);

            int idOrdreAchatEnchere = eDAO.idOrdreAchatEnchereDAO;
            OrdreAchatViewModel oa = OrdreAchatORM.getOrdreAchat(idOrdreAchatEnchere);

            EnchereViewModel e = new EnchereViewModel(eDAO.idEnchereDAO, eDAO.prixEnchereDAO, eDAO.dateEnchereDAO,
                eDAO.adjugeDAO, u, l, cp, oa);
            return e;
        }

        public static ObservableCollection<EnchereViewModel> listeEncheres()
        {
            ObservableCollection<EnchereDAO> lDAO = EnchereDAO.listeEncheres();
            ObservableCollection<EnchereViewModel> l = new ObservableCollection<EnchereViewModel>();
            foreach (EnchereDAO element in lDAO)
            {
                int idUtilisateur = element.idUtilisateurEnchereDAO;
                UtilisateurViewModel u = UtilisateurORM.getUtilisateur(idUtilisateur);

                int idCommissairePriseur = element.idCommissairePriseurEnchereDAO;
                CommissairePriseurViewModel cp = CommissairePriseurORM.getCommissairePriseur(idCommissairePriseur);

                int idlotEnchere = element.idLotEnchereDAO;
                LotViewModel lo = LotORM.getLot(idlotEnchere);

                int idOrdreAchatEnchere = element.idOrdreAchatEnchereDAO;
                OrdreAchatViewModel oa = OrdreAchatORM.getOrdreAchat(idOrdreAchatEnchere);

                EnchereViewModel e = new EnchereViewModel(element.idEnchereDAO, element.prixEnchereDAO,
                    element.dateEnchereDAO, element.adjugeDAO, u, lo, cp, oa);
                l.Add(e);
            }

            return l;
        }


        public static void updateEnchere(EnchereViewModel e)
        {
            EnchereDAO.updateEnchere(new EnchereDAO(e.idEnchereProperty, e.prixEnchereProperty, e.dateEnchereProperty,
                e.adjugeProperty,
                e.idCommissairePriseurEnchereProperty.idPersonneProperty,
                e.idUtilisateurEnchereProperty.idPersonneUtilisateurProperty,
                e.idLotEnchereProperty.idLotProperty, e.idOrdreAchatEnchereProperty.idOrdreAchatProperty));
        }

        public static void supprimerEnchere(int id)
        {
            EnchereDAO.supprimerEnchere(id);
        }

        public static void insertEnchere(EnchereViewModel e)
        {
            EnchereDAO.insertEnchere(new EnchereDAO(e.idEnchereProperty, e.prixEnchereProperty, e.dateEnchereProperty,
                e.adjugeProperty,
                e.idCommissairePriseurEnchereProperty.idPersonneProperty,
                e.idUtilisateurEnchereProperty.idPersonneUtilisateurProperty,
                e.idLotEnchereProperty.idLotProperty, e.idOrdreAchatEnchereProperty.idOrdreAchatProperty));
        }
    }
}