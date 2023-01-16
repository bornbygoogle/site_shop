namespace BlazorApp.Shared
{
    public class SwanShopArticle : BaseDto
    {
        private long? _id;

        private long? _categorieId;
        private long? _subCategorieId;

        private string _title;
        private string _subTitle;

        private string _description;
        private string _colors;
        private string _specification;

        private decimal? _price;

        private long? _nbrSold;

        public long? Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public long? CategorieId
        {
            get { return _categorieId; }
            set
            {
                _categorieId = value;
            }
        }

        public long? SubCategorieId
        {
            get { return _subCategorieId; }
            set
            {
                _subCategorieId = value;
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
            }
        }
        public string SubTitle
        {
            get { return _subTitle; }
            set
            {
                _subTitle = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }

        public string Colors
        {
            get { return _colors; }
            set
            {
                _colors = value;
            }
        }

        public string Specification
        {
            get { return _specification; }
            set
            {
                _specification = value;
            }
        }

        public decimal? Price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }

        public long? NbrSold
        {
            get { return _nbrSold; }
            set
            {
                _nbrSold = value;
            }
        }

        public SwanShopArticle() { }

        public SwanShopArticle(bool initAll)
        {
            if (initAll)
            {

            }
        }

        public bool HasDataChanged()
        {
            return HasChange == "1";
        }

        public void ClearAllChanges()
        {
            this.HasChange = null;
        }
    }
}
