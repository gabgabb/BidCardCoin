using System;
using System.ComponentModel;

namespace WpfApp11
{
    public class PersonneViewModel : INotifyPropertyChanged
    {
        protected int idPersonne;
        protected string nomPersonne;
        protected string prenomPersonne;
        protected DateTime dateNaisPersonne;
        protected string emailPersonne;
        protected string password;
        protected string telephonePersonne;
        protected int verifId;
        protected int age;

        public PersonneViewModel(int idPersonne, string nomPersonne, string prenomPersonne, DateTime dateNaisPersonne,
            string emailPersonne, string password, string telephonePersonne, int verifId)
        {
            this.idPersonne = idPersonne;
            this.nomPersonne = nomPersonne;
            this.prenomPersonne = prenomPersonne;
            this.dateNaisPersonne = dateNaisPersonne;
            this.emailPersonne = emailPersonne;
            this.password = password;
            this.telephonePersonne = telephonePersonne;
            this.verifId = verifId;

        }

        public PersonneViewModel()
        {
        }
        
        public int idPersonneProperty
        {
            get { return idPersonne; }
            set
            {
                idPersonne = value;
                
            }
        }

        public string nomPersonneProperty
        {
            get { return nomPersonne; }
            set
            {
                nomPersonne = value;
                OnPropertyChanged("nomPersonneProperty"); // indique au système de binding que la valeur a changé
            }
        }

        public string prenomPersonneProperty
        {
            get { return prenomPersonne; }
            set
            {
                this.prenomPersonne = value;
                OnPropertyChanged("prenomPersonneProperty");
            }
        }

        public DateTime DateNaisPersonneProperty
        {
            get => dateNaisPersonne;
            set => dateNaisPersonne = value;
        }

        public int AgeProperty
        {
            get { return age; }
            set
            {
                this.age = value;
                OnPropertyChanged("AgeProperty");
            }
        }

        public string emailProperty
        {
            get { return emailPersonne; }
            set
            {
                this.emailPersonne = value;
                OnPropertyChanged("emailProperty");
            }
        }

        public string passwordProperty
        {
            get { return password; }
            set
            {
                this.password = value;
                OnPropertyChanged("passwordProperty");
            }
        }

        public string telephoneProperty
        {
            get { return telephonePersonne; }
            set
            {
                this.telephonePersonne = value;
                OnPropertyChanged("telephoneProperty");
            }
        }

        public int verifIdProperty
        {
            get { return verifId; }
            set
            {
                this.verifId = value;
                OnPropertyChanged("verifIdProperty");
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
                if ((info != "AgeProperty") && MainWindow.onglet == "grille")
                {
                    PersonneORM.updatePersonne(this);
                }
            }
        }
    }
}