using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class CategorieORM
    {

        public static CategorieViewModel getCategorie(int idCategorie)
        {
            CategorieDAO cDAO = CategorieDAO.getCategorie(idCategorie);

            //int idProduit = cDAO.idProduitCategorie;
            //ProduitViewModel pro = ProduitORM.getProduit(idProduit);

            CategorieViewModel c = new CategorieViewModel(cDAO.idCategorieDAO, cDAO.nomCategorieDAO,
                cDAO.descriptionCategorieDAO);
            return c;
        }

        public static ObservableCollection<CategorieViewModel> listeCategories()
        {
            ObservableCollection<CategorieDAO> lDAO = CategorieDAO.listeCategories();
            ObservableCollection<CategorieViewModel> l = new ObservableCollection<CategorieViewModel>();
            foreach (CategorieDAO element in lDAO)
            {
                //int idProduit = element.idProduitCategorieDAO;
                //ProduitViewModel pro = ProduitORM.getProduit(idProduit);

                CategorieViewModel c = new CategorieViewModel(element.idCategorieDAO, element.nomCategorieDAO,
                    element.descriptionCategorieDAO);
                l.Add(c);
            }

            return l;
        }


        public static void updateCategorie(CategorieViewModel c)
        {
            CategorieDAO.updateCategorie(new CategorieDAO(c.idCategorieProperty, c.nomCategorieProperty,
                c.descriptionCategorieProperty));
        }

        public static void supprimerCategorie(int id)
        {
            CategorieDAO.supprimerCategorie(id);
        }

        public static void insertCategorie(CategorieViewModel c)
        {
            CategorieDAO.insertCategorie(new CategorieDAO(c.idCategorieProperty, c.nomCategorieProperty,
                c.descriptionCategorieProperty));
        }
    }
}