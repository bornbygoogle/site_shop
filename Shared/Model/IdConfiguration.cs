using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Shared
{
    public class IdConfiguration : BaseDto
    {
        public string Id { get; set; }
        public List<SiteProperty> Properties { get; set; }

        public IdConfiguration() { }

        public IdConfiguration(bool initAll)
        {
            if (initAll)
            {
                Properties = new List<SiteProperty>();
                Properties.Add(new SiteProperty());
            }
        }

        public bool HasDataChanged()
        {
            return Properties.Any(x => x.HasChange == "1");
        }
    }
}
