using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class EstimationORM
    {

        public static EstimationViewModel getEstimation(int idProduitEs, int idCommissairePriseurEs)
        {
            EstimationDAO pDAO = EstimationDAO.getEstimation(idProduitEs, idCommissairePriseurEs);

            int idProduit = pDAO.idProduitEstimationDAO;
            ProduitViewModel pro = ProduitORM.getProduit(idProduit);

            int idCommissairePriseur = pDAO.idCommissairePriseurEstimationDAO;
            CommissairePriseurViewModel cp = CommissairePriseurORM.getCommissairePriseur(idCommissairePriseur);


            EstimationViewModel p = new EstimationViewModel(pro, cp, pDAO.DateEstimationDAO, pDAO.prixEstimeDAO);
            return p;
        }

        public static ObservableCollection<EstimationViewModel> listeEstimations()
        {
            ObservableCollection<EstimationDAO> lDAO = EstimationDAO.listeEstimations();
            ObservableCollection<EstimationViewModel> l = new ObservableCollection<EstimationViewModel>();
            foreach (EstimationDAO element in lDAO)
            {
                int idProduit = element.idProduitEstimationDAO;
                ProduitViewModel pro = ProduitORM.getProduit(idProduit);

                int idCommissairePriseur = element.idCommissairePriseurEstimationDAO;
                CommissairePriseurViewModel cp = CommissairePriseurORM.getCommissairePriseur(idCommissairePriseur);

                EstimationViewModel p =
                    new EstimationViewModel(pro, cp, element.DateEstimationDAO, element.prixEstimeDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateEstimation(EstimationViewModel p)
        {
            EstimationDAO.updateEstimation(new EstimationDAO(p.idProduitEstimationProperty.idProduitProperty,
                p.idCommissairePriseurEstimationProperty.idPersonneProperty,
                p.dateEstimationProperty, p.prixEstimeProperty));
        }

        public static void supprimerEstimation(int id1, int id2)
        {
            EstimationDAO.supprimerEstimation(id1,id2);
        }

        public static void insertEstimation(EstimationViewModel p)
        {
            EstimationDAO.insertEstimation(new EstimationDAO(p.idProduitEstimationProperty.idProduitProperty,
                p.idCommissairePriseurEstimationProperty.idPersonneProperty,
                p.dateEstimationProperty, p.prixEstimeProperty));
        }
    }
}