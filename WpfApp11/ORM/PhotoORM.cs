using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class PhotoORM
    {

        public static PhotoViewModel getPhoto(int idPhoto)
        {
            PhotoDAO phDAO = PhotoDAO.getPhoto(idPhoto);

            int idProduit = phDAO.idProduitDAO;
            ProduitViewModel pro = ProduitORM.getProduit(idProduit);

            PhotoViewModel ph = new PhotoViewModel(phDAO.idPhotoDAO, phDAO.nomPhotoDAO, phDAO.lienPhotoDAO, pro);
            return ph;
        }

        public static ObservableCollection<PhotoViewModel> listePhotos()
        {
            ObservableCollection<PhotoDAO> lDAO = PhotoDAO.listePhotos();
            ObservableCollection<PhotoViewModel> l = new ObservableCollection<PhotoViewModel>();
            foreach (PhotoDAO element in lDAO)
            {
                int idProduit = element.idProduitDAO;
                ProduitViewModel pro = ProduitORM.getProduit(idProduit);

                PhotoViewModel ph =
                    new PhotoViewModel(element.idPhotoDAO, element.nomPhotoDAO, element.lienPhotoDAO, pro);
                l.Add(ph);
            }

            return l;
        }


        public static void updatePhoto(PhotoViewModel ph)
        {
            PhotoDAO.updatePhoto(new PhotoDAO(ph.idPhotoProperty, ph.nomPhotoProperty, ph.lienPhotoProperty,
                ph.idProduitProperty.idProduitProperty));
        }

        public static void supprimerPhoto(int id)
        {
            PhotoDAO.supprimerPhoto(id);
        }

        public static void insertPhoto(PhotoViewModel ph)
        {
            PhotoDAO.insertPhoto(new PhotoDAO(ph.idPhotoProperty, ph.nomPhotoProperty, ph.lienPhotoProperty,
                ph.idProduitProperty.idProduitProperty));
        }
    }
}