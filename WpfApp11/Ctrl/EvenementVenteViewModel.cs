using System.ComponentModel;

namespace WpfApp11
{
    public class EvenementVenteViewModel : INotifyPropertyChanged
    {
        private int idEvenementVente;
        private int estVolontaireEvenementVente;
        private string nomEvenementVente;
        private CommissairePriseurViewModel idCommissairePriseurEvenementVente;
        private AdresseViewModel idAdresseEvenementVente;

        public EvenementVenteViewModel(int idEvenementVente, int estVolontaireEvenementVente, string nomEvenementVente, CommissairePriseurViewModel idCommissairePriseurEvenementVente, AdresseViewModel idAdresseEvenementVente)
        {
            this.idEvenementVente = idEvenementVente;
            this.estVolontaireEvenementVente = estVolontaireEvenementVente;
            this.nomEvenementVente = nomEvenementVente;
            this.idCommissairePriseurEvenementVente = idCommissairePriseurEvenementVente;
            this.idAdresseEvenementVente = idAdresseEvenementVente;
        }
        
        public int idEvenementVenteProperty
        {
            get { return idEvenementVente; }
            set
            {
                this.idEvenementVente = value;
            }

        }
        
        public int estVolontaireEvenementVenteProperty
        {
            get { return estVolontaireEvenementVente; }
            set
            {
                this.estVolontaireEvenementVente = value;
                
                OnPropertyChanged("estVolontaireEvenementVenteProperty");
            }
        }
        
        public string nomEvenementVenteProperty
        {
            get { return nomEvenementVente; }
            set
            {
                this.nomEvenementVente = value;
                
                OnPropertyChanged("nomEvenementVenteProperty");
            }
        }
        
        public CommissairePriseurViewModel idCommissairePriseurEvenementVenteProperty
        {
            get { return idCommissairePriseurEvenementVente; }
            set
            {
                this.idCommissairePriseurEvenementVente = value;
                
                OnPropertyChanged("idCommissairePriseurEvenementVenteProperty");
            }
        }
        
        public AdresseViewModel idAdresseEvenementVenteProperty
        {
            get { return idAdresseEvenementVente; }
            set
            {
                this.idAdresseEvenementVente = value;
                
                OnPropertyChanged("idAdresseEvenementVenteProperty");
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
                    EvenementVenteORM.updateEvenementVente(this);
                }
            }
        }
    }
}