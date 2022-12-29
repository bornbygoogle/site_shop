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
                _name = value;
            }
        }
        public string Value
        {
            get { return _value; }
            set
            {
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
