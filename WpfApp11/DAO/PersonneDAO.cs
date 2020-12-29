using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class PersonneDAO
    {
        public int idPersonneDAO;
        public string nomPersonneDAO;
        public string prenomPersonneDAO;
        public DateTime dateNaisPersonneDAO;
        public string emailDAO;
        public string passwordDAO;
        public string telephoneDAO;
        public int verifIdDAO;
        
        public PersonneDAO(int idPersonneDao, string nomPersonneDao, string prenomPersonneDao, DateTime dateNaisPersonneDao, string emailDao, string passwordDao, string telephoneDao, int verifIdDao)
        {
            idPersonneDAO = idPersonneDao;
            nomPersonneDAO = nomPersonneDao;
            prenomPersonneDAO = prenomPersonneDao;
            dateNaisPersonneDAO = dateNaisPersonneDao;
            emailDAO = emailDao;
            passwordDAO = passwordDao;
            telephoneDAO = telephoneDao;
            verifIdDAO = verifIdDao;
        }
        
        public static ObservableCollection<PersonneDAO>  listePersonnes()
        {
            ObservableCollection<PersonneDAO> l = PersonneDAL.selectPersonnes();
            return l;
        }

        public static PersonneDAO getPersonne(int idPersonne)
        {
            PersonneDAO p = PersonneDAL.getPersonne(idPersonne);
            return p;
        }

        public static void updatePersonne(PersonneDAO p)
        {
            PersonneDAL.updatePersonne(p);
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAL.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneDAO p)
        {
            PersonneDAL.insertPersonne(p);
        }
    }
}
