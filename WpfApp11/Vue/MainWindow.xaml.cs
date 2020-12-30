using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Navigation;


namespace WpfApp11
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string onglet;
        
        int selectedUtilisateurId;
        int selectedProduitId; 
        int selectedCategorieId;
        int selectedCpid;

        UtilisateurViewModel myDateObjectUtilisateur; // Objet de liaison avec la vue lors de l'ajout d'une personne par exemple.
        ProduitViewModel myDateObjectProduit;
        CategorieViewModel myDateObjectCategorie;
        CommissairePriseurViewModel myDateObjectCp;

        ObservableCollection<UtilisateurViewModel> lu;
        ObservableCollection<ProduitViewModel> lpro;
        ObservableCollection<CategorieViewModel> lcat;
        ObservableCollection<CommissairePriseurViewModel> lcp;
        
        int compteur = 0;

        public MainWindow()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            // Initialisation de la liste des personnes via la BDD.
            LoadUtilisateur();
            LoadCommissairePriseur();
            //loadProduits();
            //loadCategories();

            AppliquerContexteUtilisateur();
            AppliquerContexteCp();
            //AppliquerContexteCategorie();
            //AppliquerContexteProduit();
            
        }
            
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        ///////////////////////   Utilisateur  /////////////////////////
        ////////////////////// Commissaire Priseur /////////////////////
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////

        public void PrenomChanged(object sender, TextChangedEventArgs e)
        {
            myDateObjectUtilisateur.prenomPersonneProperty = prenomTextBox.Text;
        }
        public void NomChanged(object sender, TextChangedEventArgs e)
        {
            myDateObjectUtilisateur.nomPersonneProperty = nomTextBox.Text;
        }

        public void AgeChanged(object sender, TextChangedEventArgs e)
        {
            myDateObjectUtilisateur.AgeProperty =  Convert.ToInt32(txtAge.Text);
        }

         public void EmailChanged(object sender, TextChangedEventArgs e)
        {
            myDateObjectUtilisateur.emailProperty =  txtEmail.Text;
        }

         public void TelephoneChanged(object sender, TextChangedEventArgs e)
        {
            myDateObjectUtilisateur.telephoneProperty =  txtTel.Text;
        }
         public void PasswordChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectUtilisateur.passwordProperty =  txtPassword.Text;
         }
         public void EstFrancaisChanged(object sender, TextChangedEventArgs e)
        {
            myDateObjectUtilisateur.estFrancaisProperty =  Convert.ToInt32(boolFr.Text);
        }
         
         public void EstSolvableChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectUtilisateur.verifSolvableProperty =  Convert.ToInt32(solvableBool.Text);
         }
         
         public void VerifIdChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectUtilisateur.verifIdProperty =  Convert.ToInt32(idBool.Text);
         }
         
         public void MethodePaiementChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectUtilisateur._ModePaiementDAOProperty =  methoTxt.Text;
         }
         
        
         private void UtilisateurButton_Click(object sender, RoutedEventArgs e)
         {
             DateTime anneeDeNaissance = new DateTime(2020 - myDateObjectUtilisateur.AgeProperty, 1, 1);
             myDateObjectUtilisateur.idPersonneUtilisateurProperty = UtilisateurDAL.getMaxIdUtilisateur() + 1;
             //myDataObject.MetierPersonneProperty = new  MetierViewModel(1, "boulanger");
             myDateObjectUtilisateur.DateNaisPersonneProperty = anneeDeNaissance;

             lu.Add(myDateObjectUtilisateur);
             UtilisateurORM.insertUtilisateur(myDateObjectUtilisateur);
             compteur = lu.Count();

             // Comme on a inséré une personne, on crée un nouvel objet PersonneViewModel
             // Et on réatache tout ce qu'il faut pour que la vue soit propre
             listeUtilisateur.Items.Refresh();
             myDateObjectUtilisateur = new UtilisateurViewModel();

             // Comme le contexte des élément de la vue est encore l'ancien PersonneViewModel,
             // On refait les liens entre age, slider, textbox, bouton et le nouveau PersonneViewModel
             nomTextBox.DataContext = myDateObjectUtilisateur;
             prenomTextBox.DataContext = myDateObjectUtilisateur;
             AjouterBoutonUtilisateur.DataContext = myDateObjectUtilisateur;
             txtAge.DataContext = myDateObjectUtilisateur;
             txtEmail.DataContext = myDateObjectUtilisateur;
             txtTel.DataContext = myDateObjectUtilisateur;
             txtPassword.DataContext = myDateObjectUtilisateur;
             boolFr.DataContext = myDateObjectUtilisateur;
             solvableBool.DataContext = myDateObjectUtilisateur;
             idBool.DataContext = myDateObjectUtilisateur;
         }
         
         void AppliquerContexteUtilisateur()
         {
             // Lien avec les textbox
             nomTextBox.DataContext = myDateObjectUtilisateur;
             prenomTextBox.DataContext = myDateObjectUtilisateur;
             AjouterBoutonUtilisateur.DataContext = myDateObjectUtilisateur;       
             txtAge.DataContext = myDateObjectUtilisateur;
             txtEmail.DataContext = myDateObjectUtilisateur;
             txtTel.DataContext = myDateObjectUtilisateur;
             txtPassword.DataContext = myDateObjectUtilisateur;
             boolFr.DataContext = myDateObjectUtilisateur;
             solvableBool.DataContext = myDateObjectUtilisateur;
             idBool.DataContext = myDateObjectUtilisateur;
         }
         
         ////////////////////////////////////////////////////////////////
         ////////////////////////////////////////////////////////////////
         /////////////////// Commissaire priseur  ///////////////////////
         ////////////////////////////////////////////////////////////////
         ////////////////////////////////////////////////////////////////
         ////////////////////////////////////////////////////////////////
         
         public void EstVolontaireChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectCp.estVolontaireProperty =  Convert.ToInt32(volbool.Text);
         }
         
         public void FormationChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectCp.formationProperty =  formationTxt.Text;
         }
         
         public void VerifFormationChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectCp.verifFormationProperty =  Convert.ToInt32(verifbool.Text);
         }
         
         private void liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             if ((listeUtilisateur.SelectedIndex < lu.Count) && (listeUtilisateur.SelectedIndex >= 0))
             {
                 selectedUtilisateurId = (lu.ElementAt<UtilisateurViewModel>(listeUtilisateur.SelectedIndex).idPersonneUtilisateurProperty);
             }

             if((listeCPs.SelectedIndex<lcp.Count)&& (listeCPs.SelectedIndex >= 0))
            {
                selectedCpid = (lcp.ElementAt<CommissairePriseurViewModel>(listeCPs.SelectedIndex).idPersonneCpProperty);
            }
         }
         
         private void CpButton_Click(object sender, RoutedEventArgs e)
         {
             DateTime anneeDeNaissance = new DateTime(2020 - myDateObjectCp.AgeProperty, 1, 1);
             myDateObjectCp.idPersonneCpProperty = CommissairePriseurDAL.getMaxIdCommissairePriseur() + 1;
             //myDataObject.MetierPersonneProperty = new  MetierViewModel(1, "boulanger");
             myDateObjectCp.DateNaisPersonneProperty = anneeDeNaissance;

             lcp.Add(myDateObjectCp);
             CommissairePriseurORM.insertCommissairePriseur(myDateObjectCp);
             compteur = lu.Count();

             // Comme on a inséré une personne, on crée un nouvel objet PersonneViewModel
             // Et on réatache tout ce qu'il faut pour que la vue soit propre
             listeCPs.Items.Refresh();
             myDateObjectCp = new CommissairePriseurViewModel();

             // Comme le contexte des élément de la vue est encore l'ancien PersonneViewModel,
             // On refait les liens entre age, slider, textbox, bouton et le nouveau PersonneViewModel
             nomTextBoxCp.DataContext = myDateObjectCp;
             prenomTextBoxCp.DataContext = myDateObjectCp;
             AjouterBoutonCp.DataContext = myDateObjectCp;
             txtAgeCp.DataContext = myDateObjectCp;
             txtEmailCp.DataContext = myDateObjectCp;
             txtPasswordCp.DataContext = myDateObjectCp;
             txtTelCp.DataContext = myDateObjectCp;
             idBoolCp.DataContext = myDateObjectCp;
             volbool.DataContext = myDateObjectCp;
             formationTxt.DataContext = myDateObjectCp;
             verifbool.DataContext = myDateObjectCp;
           
         }
         
         void AppliquerContexteCp()
         {
             // Lien avec les textbox
             nomTextBoxCp.DataContext = myDateObjectCp;
             prenomTextBoxCp.DataContext = myDateObjectCp;
             AjouterBoutonCp.DataContext = myDateObjectCp;
             txtAgeCp.DataContext = myDateObjectCp;
             txtEmailCp.DataContext = myDateObjectCp;
             txtPasswordCp.DataContext = myDateObjectCp;
             txtTelCp.DataContext = myDateObjectCp;
             idBoolCp.DataContext = myDateObjectCp;
             volbool.DataContext = myDateObjectCp;
             formationTxt.DataContext = myDateObjectCp;
             verifbool.DataContext = myDateObjectCp;
         }
         
         void TabControlOnglet_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
         {
             switch (OngletsUtilisateur.SelectedIndex)
             {
                
                 case 0: if(onglet!="grille") LoadUtilisateur(); onglet = "grille";  break;
                 case 1: onglet = "ajouter"; break;
            }
             switch (OngletsCp.SelectedIndex)
             {
                case 0: if (onglet != "grille") LoadCommissairePriseur(); onglet = "grille"; break;
                case 1: onglet = "ajouter"; break;
                 
             }/*
             switch (OngletsProd.SelectedIndex)
             {
                 case 0: onglet = "ajouter"; break;
                 case 1: if(onglet!="grille") LoadCommissairePriseur(); onglet = "grille";  break;
             }
             switch (OngletsCat.SelectedIndex)
             {
                 case 0: onglet = "ajouter"; break;
                 case 1: if(onglet!="grille") LoadCommissairePriseur(); onglet = "grille";  break;
             }*/
         }
         void LoadCommissairePriseur()
         {
             lcp = CommissairePriseurORM.listeCommissairePriseurs();
             myDateObjectCp = new CommissairePriseurViewModel();
             //LIEN AVEC la VIEW
             listeCPs.ItemsSource = lcp; // bind de la liste avec la source, permettant le binding.
         }
         
         void LoadUtilisateur()
         {
             lu = UtilisateurORM.listeUtilisateurs();
             myDateObjectUtilisateur = new UtilisateurViewModel();
             //LIEN AVEC la VIEW
             listeUtilisateur.ItemsSource = lu; // bind de la liste avec la source, permettant le binding.
         }
         
         
         /*
         ////////////////////////////////////////////////////////////////
         ////////////////////////////////////////////////////////////////
         ///////////////////////   Produit   ////////////////////////////
         ///////////////////////   Categorie ////////////////////////////
         ////////////////////////////////////////////////////////////////
         ////////////////////////////////////////////////////////////////
         ////////////////////////////////////////////////////////////////
         
         public void idCatChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectCategorie.idCategorieProperty = Convert.ToInt32(idCat.Text);
         }
         public void NomProduitChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectProduit.nomProduitProperty = nomProduitTxt.Text;
         }

         public void PrixReserveChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectProduit.prixReserveProperty =  Convert.ToDouble(prixReserveTxt.Text);
         }
         
         public void PrixDepartChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectProduit.prixDepartProperty =  Convert.ToDouble(prixDepartTxt.Text);
         }
         
         public void EstVenduChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectProduit.estVenduProperty = Convert.ToInt32(venduBool.Text);
         }
        
         public void PrixVenteChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectProduit.prixVenteProperty =  Convert.ToDouble(prixVenteTxt.Text);
         }
         
         private void listeProduit_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             if ((listeProd.SelectedIndex < lpro.Count) && (listeProd.SelectedIndex >= 0))
             {
                 selectedProduitId = (lpro.ElementAt<ProduitViewModel>(listeProd.SelectedIndex)).idProduitProperty;
             }
         }
         
         private void ProduitButton_Click(object sender, RoutedEventArgs e)
         {
            
             myDateObjectProduit.idProduitProperty = ProduitDAL.getMaxIdProduit() + 1;
             //myDataObject.MetierPersonneProperty = new  MetierViewModel(1, "boulanger");

             lpro.Add(myDateObjectProduit);
             ProduitORM.insertProduit(myDateObjectProduit);
             compteur = lu.Count();

             // Comme on a inséré une personne, on crée un nouvel objet PersonneViewModel
             // Et on réatache tout ce qu'il faut pour que la vue soit propre
             listeCats.Items.Refresh();
             myDateObjectProduit = new ProduitViewModel();

             // Comme le contexte des élément de la vue est encore l'ancien PersonneViewModel,
             // On refait les liens entre age, slider, textbox, bouton et le nouveau PersonneViewModel
             nomProduitTxt.DataContext = myDateObjectProduit;
             AjouterBoutonPro.DataContext = myDateObjectProduit;
             prixReserveTxt.DataContext = myDateObjectProduit;
             prixDepartTxt.DataContext = myDateObjectProduit;
             venduBool.DataContext = myDateObjectProduit;
             prixVenteTxt.DataContext = myDateObjectProduit;
            
         }
         
         void loadProduits()
         {
             lpro = ProduitORM.listeProduits();
             myDateObjectProduit = new ProduitViewModel();

             listeProd.ItemsSource = lpro;
         }
         
         void AppliquerContexteProduit()
         {
             // Lien avec les textbox
             nomProduitTxt.DataContext = myDateObjectProduit;
             prixReserveTxt.DataContext = myDateObjectProduit;
             AjouterBoutonPro.DataContext = myDateObjectProduit;
             prixDepartTxt.DataContext = myDateObjectProduit;
             venduBool.DataContext = myDateObjectProduit;
             prixVenteTxt.DataContext = myDateObjectProduit;
         }
         
         ////////////////////////////////////////////////////////////////
         ////////////////////////////////////////////////////////////////
         ///////////////////////   Catégorie  ///////////////////////////
         ////////////////////////////////////////////////////////////////
         ////////////////////////////////////////////////////////////////
         ////////////////////////////////////////////////////////////////
         
         public void NomCategorieChanged(object sender, TextChangedEventArgs e)
         {
             myDateObjectCategorie.nomCategorieProperty = nomCatTextBox.Text;
         }
         

         private void CategorieButton_Click(object sender, RoutedEventArgs e)
         {
            
             myDateObjectCategorie.idCategorieProperty = CategorieDAL.getMaxIdCategorie() + 1;
             //myDataObject.MetierPersonneProperty = new  MetierViewModel(1, "boulanger");

             lcat.Add(myDateObjectCategorie);
             CategorieORM.insertCategorie(myDateObjectCategorie);
             compteur = lcat.Count();

             // Comme on a inséré une personne, on crée un nouvel objet PersonneViewModel
             // Et on réatache tout ce qu'il faut pour que la vue soit propre
             listeCats.Items.Refresh();
             myDateObjectCategorie = new CategorieViewModel();

             // Comme le contexte des élément de la vue est encore l'ancien PersonneViewModel,
             // On refait les liens entre age, slider, textbox, bouton et le nouveau PersonneViewModel
             nomCatTextBox.DataContext = myDateObjectCategorie;
            
         }
         
         void loadCategories()
         {
             lcat= CategorieORM.listeCategories();
             myDateObjectCategorie = new CategorieViewModel();

             listeCats.ItemsSource = lcat;
         }
         
         void AppliquerContexteCategorie()
         {
             // Lien avec les textbox
             nomCatTextBox.DataContext = myDateObjectCategorie;
             
         }
         
         private void listeCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             if ((listeCats.SelectedIndex < lcat.Count) && (listeCats.SelectedIndex >= 0))
             {
                 selectedCategorieId = (lcat.ElementAt<CategorieViewModel>(listeCats.SelectedIndex)).idCategorieProperty;
             }
         }
         
         */
         
        private void supprimerButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {


            if (listeUtilisateur.SelectedItem is UtilisateurViewModel)
            {
                
                UtilisateurViewModel toRemove = (UtilisateurViewModel)listeUtilisateur.SelectedItem;
                lu.Remove(toRemove);
                listeUtilisateur.Items.Refresh();
                UtilisateurORM.supprimerUtilisateur(selectedUtilisateurId);
              
            }

            if (listeCPs.SelectedItem is CommissairePriseurViewModel)
            {
                CommissairePriseurViewModel toRemove = (CommissairePriseurViewModel)listeCPs.SelectedItem;
                lcp.Remove(toRemove);
                listeCPs.Items.Refresh();
                CommissairePriseurORM.supprimerCommissairePriseur(selectedCpid);
            }
            /*
            if(listeCats.SelectedItem is ProduitViewModel)
            {
                ProduitViewModel toRemove = (ProduitViewModel) listeCats.SelectedItem;
                lpro.Remove(toRemove);
                listeCats.Items.Refresh();
                ProduitORM.supprimerProduit(selectedProduitId);
            }*/
        }

        private void nomPrenomButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

    }
}
