using System.ComponentModel;

namespace WpfApp11
{
    public class PhotoViewModel : INotifyPropertyChanged
    {
        private int idPhoto;
        private string nomPhoto;
        private string lienPhoto;
        private ProduitViewModel idProduit;

        public PhotoViewModel(int idPhoto, string nomPhoto, string lienPhoto, ProduitViewModel idProduit)
        {
            this.idPhoto = idPhoto;
            this.nomPhoto = nomPhoto;
            this.lienPhoto = lienPhoto;
            this.idProduit = idProduit;
        }
        
        public int idPhotoProperty
        {
            get { return idPhoto; }
            set { this.idPhoto = value; }
        }
        
        public string nomPhotoProperty
        {
            get { return nomPhoto; }
            set
            {
                this.nomPhoto = value;
                
                OnPropertyChanged("nomPhotoProperty");
            }
        }
        
        public string lienPhotoProperty
        {
            get { return lienPhoto; }
            set
            {
                this.lienPhoto = value;
                
                OnPropertyChanged("lienPhotoProperty");
            }
        }   
        
        public ProduitViewModel idProduitProperty
        {
            get { return idProduit; }
            set
            {
                this.idProduit = value;
            }
        } 
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                if (MainWindow.onglet != "ajouter")
                {
                    PhotoORM.updatePhoto(this);
                }
            }
        }
        
    }
}