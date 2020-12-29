using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class AdresseDAO
    {
        
        public int idAdresseDAO;
        public int numeroDAO;
        public string rueDAO;
        public string villeDAO;
        public string codePostalDAO;
        public string paysDAO;

        public AdresseDAO(int idAdresse, int numero, string rue, string ville, string codePostal, string pays)
        {
            this.idAdresseDAO = idAdresse;
            this.numeroDAO = numero;
            this.rueDAO = rue;
            this.villeDAO = ville;
            this.codePostalDAO = codePostal;
            this.paysDAO = pays;
        }
        
        public static ObservableCollection<AdresseDAO>  listeAdresses()
        {
            ObservableCollection<AdresseDAO> l = AdresseDAL.selectAdresses();
            return l;
        }

        public static AdresseDAO getAdresse(int idAdresse)
        {
            AdresseDAO p = AdresseDAL.getAdresse(idAdresse);
            return p;
        }

        public static void updateAdresse(AdresseDAO a)
        {
            AdresseDAL.updateAdresse(a);
        }

        public static void supprimerAdresse(int id)
        {
            AdresseDAL.supprimerAdresse(id);
        }

        public static void insertAdresse(AdresseDAO a)
        {
            AdresseDAL.insertAdresse(a);
        }
    }
        
    }
