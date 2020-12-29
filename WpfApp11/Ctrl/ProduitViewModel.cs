using System;
using System.ComponentModel;

namespace WpfApp11
{
    public class ProduitViewModel : INotifyPropertyChanged
    {
   
        //public MetierViewModel metierProduit;
        private int idProduit;
        private string nomProduit;
        private string descriptionProduit;
        private double prixReserve;
        private double prixDepart;
        private int estVendu;
        private int enStock;
        private double prixVente;
        private int nbInvendu;
        private UtilisateurViewModel utilisateurProduit;
        private StockageViewModel stockageProduit;
        private LotViewModel lotProduit;

        public ProduitViewModel() { }

        public ProduitViewModel(int idProduit, string nomProduit, string description, double prixReserve,
            double prixDepart, int estVendu, int enstock, double prixVente, int nbInvendu,
            UtilisateurViewModel utilisateurProduit,StockageViewModel stockageProduit, LotViewModel lotProduit)
        {
            this.idProduit = idProduit;
            this.nomProduit = nomProduit;
            this.descriptionProduit = description;
            this.prixReserve = prixReserve;
            this.prixDepart = prixDepart;
            this.estVendu = estVendu;
            this.enStock = enstock;
            this.prixVente = prixVente;
            this.nbInvendu = nbInvendu;
            this.utilisateurProduit = utilisateurProduit;
            this.stockageProduit = stockageProduit;
            this.lotProduit = lotProduit;

        }

        public int idProduitProperty
        {
            get { return idProduit; }
            set
            {
                idProduit = value;
            }
        }
        public string nomProduitProperty
        {
            get { return nomProduit; }
            set
            {
                nomProduit = value;
                
                OnPropertyChanged("nomProduitProperty"); // indique au système de binding que la valeur a changé
            }

        }

        public string descriptionProduitProperty
        {
            get { return descriptionProduit; }
            set
            {
                descriptionProduit = value;
                OnPropertyChanged("descriptionProduitProperty"); // indique au système de binding que la valeur a changé
            }

        }

        public double prixReserveProperty
        {
            get { return prixReserve; }
            set
            {
                prixReserve = value;
                OnPropertyChanged("prixReserveProperty"); // indique au système de binding que la valeur a changé
            }

        }

        public double prixDepartProperty
        {
            get { return prixDepart; }
            set
            {
                prixDepart = value;
                OnPropertyChanged("prixDepartProperty"); // indique au système de binding que la valeur a changé
            }

        }

        public int estVenduProperty
        {
            get { return estVendu; }
            set
            {
                estVendu = value;
                OnPropertyChanged("estVenduProperty"); // indique au système de binding que la valeur a changé
            }

        }
        public int enStockProperty
        {
            get { return enStock; }
            set
            {
                enStock = value;
                OnPropertyChanged("enStockProperty"); // indique au système de binding que la valeur a changé
            }

        }

        public double prixVenteProperty
        {
            get { return prixVente; }
            set
            {
                prixVente = value;
                OnPropertyChanged("prixVenteProperty"); // indique au système de binding que la valeur a changé
            }

        }

        public int nbInvenduProperty
        {
            get { return nbInvendu; }
            set
            {
                nbInvendu = value;
                OnPropertyChanged("nbInvenduProperty"); // indique au système de binding que la valeur a changé
            }

        }

        public UtilisateurViewModel utilisateurProduitProperty
        {
            get { return utilisateurProduit; }
            set
            {
                utilisateurProduit = value;
            }
        }
        
        public StockageViewModel stockageProduitProperty
        {
            get { return stockageProduit; }
            set
            {
                stockageProduit = value;
            }
        }
        
        public LotViewModel lotProduitProperty
        {
            get { return lotProduit; }
            set
            {
                lotProduit= value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                if (MainWindow.onglet != "ajouter")
                {
                    ProduitORM.updateProduit(this);
                }
            }
        }
    }
}