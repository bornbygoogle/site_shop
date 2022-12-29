namespace BlazorApp.Shared
{
    public class SwanShopSubCategorie : BaseDto
    {
        private long? _id;
        private long? _catId;
        private string _name;
        private string _isPriority;

        public long? Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public long? CatId
        {
            get { return _catId; }
            set
            {
                _catId = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string IsPriority
        {
            get
            {
                return _isPriority;
            }
            set
            {
                _isPriority = value;
            }
        }

        public SwanShopSubCategorie() { }

        public SwanShopSubCategorie(bool initAll)
        {
            if (initAll)
            {

            }
        }

        public bool HasDataChanged()
        {
            return HasChange == "1";
        }
    }
}
