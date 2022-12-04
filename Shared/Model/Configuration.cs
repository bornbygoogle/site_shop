using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Shared
{
    public class Configuration : BaseDto
    {
        private string _route;

        public string Route
        {
            get { return _route; }
            set
            {
                if (_route != null && value != null && _route != value)
                    this.HasChange = "1";

                _route = value;
            }
        }

        public List<SiteProperty> Properties { get; set; }

        public List<IdConfiguration> SpecificIdProperties { get; set; }

        public Configuration() { }
        public Configuration(bool initAll)
        {
            if (initAll)
            {
                Properties = new List<SiteProperty>();
                Properties.Add(new SiteProperty());

                SpecificIdProperties = new List<IdConfiguration>();
                SpecificIdProperties.Add(new IdConfiguration(initAll));
            }
        }

        public bool HasDataChanged()
        {
            return (this.HasChange == "1") || (Properties != null && Properties.Any(x => x.HasDataChanged())) || (SpecificIdProperties != null && SpecificIdProperties.Any(x => x.HasDataChanged()));
        }
    }
}
