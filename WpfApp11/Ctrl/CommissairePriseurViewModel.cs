using System;
using System.ComponentModel;

namespace WpfApp11
{
    public class CommissairePriseurViewModel : PersonneViewModel
    {
        private int idPersonneCommissairePriseur;
        private int estVolontaire;
        private string formation;
        private int verifFormation;
       
        public CommissairePriseurViewModel(){}
        public CommissairePriseurViewModel(int idPersonne, string nomPersonne, string prenomPersonne,
            DateTime dateNaisPersonne, string emailPersonne, string password, string telephonePersonne, int verifId, int estVolontaire, string formation,
            int verifFormation) : base(idPersonne, nomPersonne, prenomPersonne, dateNaisPersonne, emailPersonne,
            password, telephonePersonne, verifId)
        {
            this.idPersonneCommissairePriseur = idPersonne;
            this.estVolontaire = estVolontaire;
            this.formation = formation;
            this.verifFormation = verifFormation;
           
        }

        public  int idPersonneCpProperty 
        {
            get { return idPersonneCommissairePriseur; }
            set
            {
                idPersonneCommissairePriseur = value;
            }
        }
        public int estVolontaireProperty
        {
            get { return estVolontaire; }
            set
            {
                this.estVolontaire = value;
                OnPropertyChanged("estVolontaireProperty"); // indique au système de binding que la valeur a changé
            }

        }
        public string formationProperty
        {
            get { return formation; }
            set
            {
                this.formation = value;
                
                OnPropertyChanged("formationProperty");
            }
        }
        
        public int verifFormationProperty
        {
            get { return verifFormation; }
            set
            {
                this.verifFormation = value;
                
                OnPropertyChanged("verifFormationProperty");
            }
        }
        
        public  event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                if (MainWindow.onglet != "ajouter")
                {
                    CommissairePriseurORM.updateCommissairePriseur(this);
                }
            }
        }
    }
}