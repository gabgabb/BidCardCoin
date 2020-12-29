using System;
using System.ComponentModel;

namespace WpfApp11
{
    public class AdresseViewModel : INotifyPropertyChanged
    {
        private int idAdresse;
        private int numero;
        private string rue;
        private string ville;
        private string codePostal;
        private string pays;

        public AdresseViewModel(){}
        public AdresseViewModel(int idAdresse, int numero, string rue, string ville, string codePostal, string pays)
        {
            this.idAdresse = idAdresse;
            this.numero = numero;
            this.rue = rue;
            this.ville = ville;
            this.codePostal = codePostal;
            this.pays = pays;
        }
        
        public int idAdresseProperty
        {
            get { return idAdresse; }
            set
            {
                idAdresse = value;
            }
        }
        public int numeroProperty
        {
            get { return numero; }
            set
            {
                this.numero = value;
                OnPropertyChanged("numeroProperty"); // indique au système de binding que la valeur a changé
            }

        }
        public string rueProperty
        {
            get { return rue; }
            set
            {
                this.rue = value;
                
                OnPropertyChanged("rueProperty");
            }
        }
        
        public string villeProperty
        {
            get { return ville; }
            set
            {
                this.ville = value;
                
                OnPropertyChanged("villeProperty");
            }
        }
        public string codePostalProperty
        {
            get { return codePostal; }
            set
            {
                this.codePostal = value;
                OnPropertyChanged("codePostalProperty");
            }
        }

        public string paysProperty
        {
            get{ return pays;}
            set{
                this.pays=value;
                OnPropertyChanged("paysProperty");
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
                    AdresseORM.updateAdresse(this);
                }
            }
        }
    }
}