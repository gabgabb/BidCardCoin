using System.Collections.ObjectModel;

namespace WpfApp11
{
    public class PhotoDAO
    {
        public int idPhotoDAO;
        public string nomPhotoDAO;
        public string lienPhotoDAO;
        public int idProduitDAO;

        public PhotoDAO(int idPhotoDao, string nomphotoDao, string lienPhotoDao, int idProduitDao)
        {
            idPhotoDAO = idPhotoDao;
            nomPhotoDAO = nomphotoDao;
            lienPhotoDAO = lienPhotoDao;
            idProduitDAO = idProduitDao;
        }

        public static ObservableCollection<PhotoDAO>  listePhotos()
        {
            ObservableCollection<PhotoDAO> l = PhotoDAL.selectPhotos();
            return l;
        }

        public static PhotoDAO getPhoto(int idPhoto)
        {
            PhotoDAO p = PhotoDAL.getPhoto(idPhoto);
            return p;
        }

        public static void updatePhoto(PhotoDAO p)
        {
            PhotoDAL.updatePhoto(p);
        }

        public static void supprimerPhoto(int id)
        {
            PhotoDAL.supprimerPhoto(id);
        }

        public static void insertPhoto(PhotoDAO p)
        {
            PhotoDAL.insertPhoto(p);
        }
    }
}