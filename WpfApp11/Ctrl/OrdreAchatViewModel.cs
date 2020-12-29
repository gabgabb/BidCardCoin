using System;
using System.ComponentModel;

namespace WpfApp11
{
    public class OrdreAchatViewModel : INotifyPropertyChanged
    {
        private int idOrdreAchat;
        private double prixMax;
        private DateTime dateOrdre;
        private UtilisateurViewModel idUtilisateurOrdre;
        private ProduitViewModel idProduitOrdre;

        public OrdreAchatViewModel(int idOrdreAchat, double prixMax, DateTime dateOrdre, UtilisateurViewModel idUtilisateurOrdre, ProduitViewModel idProduitOrdre)
        {
            this.idOrdreAchat = idOrdreAchat;
            this.prixMax = prixMax;
            this.dateOrdre = dateOrdre;
            this.idUtilisateurOrdre = idUtilisateurOrdre;
            this.idProduitOrdre = idProduitOrdre;
        }
        
        public int idOrdreAchatProperty
        {
            get { return idOrdreAchat; }
            set { this.idOrdreAchat = value; }
        }
        
        public double prixMaxProperty
        {
            get { return prixMax; }
            set
            {
                this.prixMax = value;
                
                OnPropertyChanged("prixMaxProperty");
            }
        }
        
        public DateTime dateOrdreProperty { get => dateOrdre; set => dateOrdre = value; }

        public UtilisateurViewModel idUtilisateurOrdreProperty
        {
            get { return idUtilisateurOrdre; }
            set { this.idUtilisateurOrdre = value; }
        }   
        
        public ProduitViewModel idProduitOrdreProperty
        {
            get { return idProduitOrdre; }
            set { this.idProduitOrdre = value; }
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
                    OrdreAchatORM.updateOrdreAchat(this);
                }
            }
        }
        
        
    }
}