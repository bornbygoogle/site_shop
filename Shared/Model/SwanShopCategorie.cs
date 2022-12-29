namespace BlazorApp.Shared
{
    public class SwanShopCategorie : BaseDto
    {
        private long? _id;
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

        public SwanShopCategorie() { }

        public SwanShopCategorie(bool initAll)
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
