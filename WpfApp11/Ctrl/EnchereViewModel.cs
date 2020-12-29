using System;
using System.ComponentModel;

namespace WpfApp11
{
    public class EnchereViewModel : INotifyPropertyChanged
    {
        private int idEnchere;
        private double prixEnchere;
        private DateTime dateEnchere;
        private int adjuge;
        private UtilisateurViewModel idUtilisateurEnchere;
        private LotViewModel idLotEnchere;
        private CommissairePriseurViewModel idCommissairePriseurEnchere;
        private OrdreAchatViewModel idOrdreAchatEnchere;

        public EnchereViewModel(int idEnchere, double prixEnchere, DateTime dateEnchere, int adjuge, UtilisateurViewModel idUtilisateurEnchere, LotViewModel idLotEnchere, CommissairePriseurViewModel idCommissairePriseurEnchere, OrdreAchatViewModel idOrdreAchatEnchere)
        {
            this.idEnchere = idEnchere;
            this.prixEnchere = prixEnchere;
            this.dateEnchere = dateEnchere;
            this.adjuge = adjuge;
            this.idUtilisateurEnchere = idUtilisateurEnchere;
            this.idLotEnchere = idLotEnchere;
            this.idCommissairePriseurEnchere = idCommissairePriseurEnchere;
            this.idOrdreAchatEnchere = idOrdreAchatEnchere;
        }
        
        public int idEnchereProperty
        {
            get { return idEnchere; }
            set
            {
                idEnchere = value;
            }
        }
        
        public double prixEnchereProperty
        {
            get { return prixEnchere; }
            set
            {
                this.prixEnchere = value;
                OnPropertyChanged("prixEnchereProperty"); // indique au système de binding que la valeur a changé
            }

        }
        
        public DateTime dateEnchereProperty { get => dateEnchere; set => dateEnchere = value; }
        
        public int adjugeProperty
        {
            get { return adjuge; }
            set
            {
                this.adjuge = value;
                
                OnPropertyChanged("adjugeProperty");
            }
        }
        
        public UtilisateurViewModel idUtilisateurEnchereProperty
        {
            get { return idUtilisateurEnchere; }
            set
            {
                this.idUtilisateurEnchere = value;
                
                OnPropertyChanged("idUtilisateurEnchereProperty");
            }
        }
        public LotViewModel idLotEnchereProperty
        {
            get { return idLotEnchere; }
            set
            {
                this.idLotEnchere = value;
                
                OnPropertyChanged("idLotEnchereProperty");
            }
        }
        public CommissairePriseurViewModel idCommissairePriseurEnchereProperty
        {
            get { return idCommissairePriseurEnchere; }
            set
            {
                this.idCommissairePriseurEnchere = value;
                
                OnPropertyChanged("idCommissairePriseurEnchereProperty");
            }
        }
        public OrdreAchatViewModel idOrdreAchatEnchereProperty
        {
            get { return idOrdreAchatEnchere; }
            set
            {
                this.idOrdreAchatEnchere = value;
                
                OnPropertyChanged("idOrdreAchatEnchereProperty");
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
                    EnchereORM.updateEnchere(this);
                }
            }
        }
    }
    
}