namespace BlazorApp.Shared
{
    public class SiteProperty : BaseDto
    {

        private string _name;
        private string _value;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != null && value != null && _name != value)
                    this.HasChange = "1";

                _name = value;
            }
        }
        public string Value
        {
            get { return _value; }
            set
            {
                if (_value != null && value != null && _value != value)
                    this.HasChange = "1";

                _value = value;
            }
        }

        public SiteProperty() { }
        public SiteProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public bool HasDataChanged()
        {
            return this.HasChange == "1";
        }
    }
}
