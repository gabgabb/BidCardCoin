using System.ComponentModel;

namespace WpfApp11
{
    public class CategorieViewModel : INotifyPropertyChanged
    {
        private int idCategorie;
        private string nomCategorie;
        private string descriptionCategorie;

        public CategorieViewModel() { }

        public CategorieViewModel(int idCategorie, string nomCategorie, string descriptionCategorie)
        {
            this.idCategorie = idCategorie;
            this.nomCategorie = nomCategorie;
            this.descriptionCategorie = descriptionCategorie;
        }
        
        public int idCategorieProperty
        {
            get { return idCategorie; }
            set
            {
                idCategorie = value;
                OnPropertyChanged("idCategorieProperty");
            }
        }
        public string nomCategorieProperty
        {
            get { return nomCategorie; }
            set
            {
                this.nomCategorie = value;
                OnPropertyChanged("nomCategorieProperty"); // indique au système de binding que la valeur a changé
            }

        }
        public string descriptionCategorieProperty
        {
            get { return descriptionCategorie; }
            set
            {
                this.descriptionCategorie = value;
                
                OnPropertyChanged("descriptionCategorieProperty");
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
                    CategorieORM.updateCategorie(this);
                }
            }
        }
    }
}