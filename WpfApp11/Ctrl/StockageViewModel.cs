using System.ComponentModel;

namespace WpfApp11
{
    public class StockageViewModel
    {
        private int idStockage;
        private AdresseViewModel idAdresseStockage;

        public StockageViewModel(int idStockage, AdresseViewModel idAdresseStockage)
        {
            this.idStockage = idStockage;
            this.idAdresseStockage = idAdresseStockage;
        }
        
        public int idStockageProperty
        {
            get { return idStockage; }
            set
            {
                this.idStockage = value;
            }
        }
        
        public AdresseViewModel idAdresseStockageProperty
        {
            get { return idAdresseStockage; }
            set
            {
                this.idAdresseStockage = value;
                
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
                    StockageORM.updateStockage(this);
                }
            }
        }
    }
}