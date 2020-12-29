using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfApp11
{
    public class CategorieDAO
    {
        
        public int idCategorieDAO;
        public string nomCategorieDAO;
        public string descriptionCategorieDAO;

        public CategorieDAO(int idCategorie, string nomCategorie, string descriptionCategorie)
        {
            this.idCategorieDAO = idCategorie;
            this.nomCategorieDAO = nomCategorie;
            this.descriptionCategorieDAO = descriptionCategorie;
            
        }
        
        public static ObservableCollection<CategorieDAO> listeCategories()
        {
            ObservableCollection<CategorieDAO> l = CategorieDAL.selectCategories();
            return l;
        }

        public static CategorieDAO getCategorie(int idCategorie)
        {
            CategorieDAO p = CategorieDAL.getCategorie(idCategorie);
            return p;
        }

        public static void updateCategorie(CategorieDAO p)
        {
            CategorieDAL.updateCategorie(p);
        }

        public static void supprimerCategorie(int id)
        {
            CategorieDAL.supprimerCategorie(id);
        }

        public static void insertCategorie(CategorieDAO p)
        {
            CategorieDAL.insertCategorie(p);
        }
    }
}