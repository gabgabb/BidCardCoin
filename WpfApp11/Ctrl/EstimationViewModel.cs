using System;
using System.ComponentModel;

namespace WpfApp11
{
    public class EstimationViewModel : INotifyPropertyChanged
    {
        private ProduitViewModel idProduitEstimation;
        private CommissairePriseurViewModel idCommissairePriseurEstimation;
        private DateTime dateEstimation;
        private double prixEstime;

        public EstimationViewModel(ProduitViewModel idProduitEstimation, CommissairePriseurViewModel idCommissairePriseurEstimation, DateTime dateEstimation, double prixEstime)
        {
            this.idProduitEstimation = idProduitEstimation;
            this.idCommissairePriseurEstimation = idCommissairePriseurEstimation;
            this.dateEstimation = dateEstimation;
            this.prixEstime = prixEstime;
        }
        
        public ProduitViewModel idProduitEstimationProperty
        {
            get { return idProduitEstimation; }
            set
            {
                idProduitEstimation = value;
            }
        }
        
        public CommissairePriseurViewModel idCommissairePriseurEstimationProperty
        {
            get { return idCommissairePriseurEstimation; }
            set
            {
                this.idCommissairePriseurEstimation = value;
            }

        }
        public DateTime dateEstimationProperty { get => dateEstimation; set => dateEstimation = value; }
        
        public double prixEstimeProperty
        {
            get { return prixEstime; }
            set
            {
                this.prixEstime = value;
                
                OnPropertyChanged("prixEstimeProperty");
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
                    EstimationORM.updateEstimation(this);
                }
            }
        }
    }
}