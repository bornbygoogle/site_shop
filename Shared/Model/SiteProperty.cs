namespace BlazorApp.Shared
{
    public class SiteProperty : BaseDto
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public SiteProperty() { }
        public SiteProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
