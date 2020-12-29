using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WpfApp11 { 

    public class ProduitORM
    {

        public static ProduitViewModel getProduit(int idProduit)
        {
            ProduitDAO pDAO = ProduitDAO.getProduit(idProduit);

            int idUtilisateur = pDAO.idUtilisateurProduitDAO;
            UtilisateurViewModel u = UtilisateurORM.getUtilisateur(idUtilisateur);

            int idStockage = pDAO.idStockageProduitDAO;
            StockageViewModel sto = StockageORM.getStockage(idStockage);

            int idLot = pDAO.idLotProduitDAO;
            LotViewModel l = LotORM.getLot(idLot);

            ProduitViewModel p = new ProduitViewModel(pDAO.idProduitDAO, pDAO.nomProduitDAO, pDAO.descriptionProduitDAO,
                pDAO.prixReserveDAO, pDAO.prixDepartDAO, pDAO.estVenduDAO, pDAO.enStockDAO,
                pDAO.prixVenteDAO, pDAO.nbInvenduDAO, u, sto, l);
            return p;
        }

        public static ObservableCollection<ProduitViewModel> listeProduits()
        {
            ObservableCollection<ProduitDAO> lDAO = ProduitDAO.listeProduits();
            ObservableCollection<ProduitViewModel> l = new ObservableCollection<ProduitViewModel>();
            foreach (ProduitDAO element in lDAO)
            {
                int idUtilisateur = element.idUtilisateurProduitDAO;
                int idStockage = element.idStockageProduitDAO;
                int idLot = element.idLotProduitDAO;

                UtilisateurViewModel u = UtilisateurORM.getUtilisateur(idUtilisateur); // Plus propre que d'aller chercher le métier dans la DAO.
                StockageViewModel sto = StockageORM.getStockage(idStockage);
                LotViewModel lo = LotORM.getLot(idLot);

                ProduitViewModel p = new ProduitViewModel(element.idProduitDAO, element.nomProduitDAO,
                    element.descriptionProduitDAO, element.prixReserveDAO, element.prixDepartDAO, element.estVenduDAO,
                    element.enStockDAO, element.prixVenteDAO, element.nbInvenduDAO, u, sto, lo);
                l.Add(p);
            }

            return l;
        }


        public static void updateProduit(ProduitViewModel p)
        {
            ProduitDAO.updateProduit(new ProduitDAO(p.idProduitProperty, p.nomProduitProperty,
                p.descriptionProduitProperty,
                p.prixReserveProperty, p.prixDepartProperty, p.estVenduProperty, p.estVenduProperty,
                p.prixVenteProperty, p.nbInvenduProperty,
                p.utilisateurProduitProperty.idPersonneUtilisateurProperty,
                p.stockageProduitProperty.idStockageProperty, p.lotProduitProperty.idLotProperty));
        }

        public static void supprimerProduit(int id)
        {
            ProduitDAO.supprimerProduit(id);
        }

        public static void insertProduit(ProduitViewModel p)
        {
            ProduitDAO.insertProduit(new ProduitDAO(p.idProduitProperty, p.nomProduitProperty,
                p.descriptionProduitProperty,
                p.prixReserveProperty, p.prixDepartProperty, p.estVenduProperty, p.estVenduProperty,
                p.prixVenteProperty, p.nbInvenduProperty,
                p.utilisateurProduitProperty.idPersonneUtilisateurProperty,
                p.stockageProduitProperty.idStockageProperty, p.lotProduitProperty.idLotProperty));
        }
    }
}
