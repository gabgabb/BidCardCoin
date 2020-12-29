using System.ComponentModel;

namespace WpfApp11
{
    public class LotViewModel : INotifyPropertyChanged
    {
        private int idLot;
        private string nomLot;
        private string descriptionLot;

        public LotViewModel(int idLot, string nomLot, string descriptionLot)
        {
            this.idLot = idLot;
            this.nomLot = nomLot;
            this.descriptionLot = descriptionLot;
        }
        
        public int idLotProperty
        {
            get { return idLot; }
            set { this.idLot = value; }
        }
        
        public string nomLotProperty
        {
            get { return nomLot; }
            set
            {
                this.nomLot = value;
                
                OnPropertyChanged("nomLotProperty");
            }
        }
        
        public string descriptionLotProperty
        {
            get { return descriptionLot; }
            set
            {
                this.descriptionLot = value;
                
                OnPropertyChanged("descriptionLotProperty");
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
                    LotORM.updateLot(this);
                }
            }
        }
    }
}