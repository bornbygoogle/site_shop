using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Shared
{
    public class Configuration : BaseDto
    {
        public string Route { get; set; }
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
            return Properties.Any(x => x.HasChange == "1") || SpecificIdProperties.Any(x => x.HasDataChanged());
        }
    }
}
