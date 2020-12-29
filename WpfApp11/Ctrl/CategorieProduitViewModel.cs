namespace WpfApp11
{
    public class CategorieProduitViewModel
    {
        private int fk_idProduit;
        private int fk_idCategorie;
        
        public CategorieProduitViewModel() { }

        public CategorieProduitViewModel(int fkIdProduit, int fkIdCategorie)
        {
            fk_idProduit = fkIdProduit;
            fk_idCategorie = fkIdCategorie;
        }
        
        public int fk_idProduitProperty
        {
            get { return fk_idProduit; }
            set
            {
                fk_idProduit = value;
                
            }
        }
        
        public int fk_idCategorieProperty
        {
            get { return fk_idCategorie; }
            set
            {
                fk_idCategorie = value;
                
            }
        }
    }
}