using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

namespace WpfApp11
{
	

public class UtilisateurViewModel : PersonneViewModel
{
	private int idPersonne;
	private string _ModePaiement;
	private int verifSolvableUser;
	private int estFrancaisPersonneUser;
	
	public UtilisateurViewModel() 
	{ }

	public UtilisateurViewModel(int idPersonne, string nomPersonne, string prenomPersonne, DateTime dateNaisPersonne,
		string emailPersonne, string password, string telephonePersonne, int verifId, string modePaiement,
		int verifSolvableUser, int estFrancaisPersonneUser) : base(idPersonne, nomPersonne, prenomPersonne,
		dateNaisPersonne, emailPersonne, password, telephonePersonne, verifId)
	{
		this.idPersonne = idPersonne;
		_ModePaiement = modePaiement;
		this.verifSolvableUser = verifSolvableUser;
		this.estFrancaisPersonneUser = estFrancaisPersonneUser;
	}
	
	public  int idPersonneUtilisateurProperty
		{
			get { return idPersonne; }
			set { this.idPersonne = value; }
		}   
    
	public string _ModePaiementDAOProperty
	{
		get { return _ModePaiement; }
		set
		{
			this._ModePaiement = value; 
			OnPropertyChanged("_ModePaiementDAOProperty");

		}
	}

		public int estFrancaisProperty
        {
            get{ return estFrancaisPersonneUser;}
            set{
                this.estFrancaisPersonneUser=value;
                OnPropertyChanged("estFrancaisProperty");
            }
        }
        
        public int verifSolvableProperty
        {
            get{ return verifSolvableUser;}
            set{
                this.verifSolvableUser=value;
                OnPropertyChanged("verifSolvableProperty");
            }
        }
        
	public event PropertyChangedEventHandler PropertyChanged;
	public  void OnPropertyChanged(string info)
	{
		PropertyChangedEventHandler handler = PropertyChanged;
		if (handler != null)
		{
			handler(this, new PropertyChangedEventArgs(info));
			this.PropertyChanged(this, new PropertyChangedEventArgs(info));
			
				UtilisateurORM.updateUtilisateur(this);
				PersonneORM.updatePersonne(this);
		}
	}
}
}


