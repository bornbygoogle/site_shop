using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Shared
{
    public class IdConfiguration : BaseDto
    {
        private string _id;

        public string Id
        {
            get { return _id; }
            set
            {
                if (_id != null && value != null && _id != value)
                    this.HasChange = "1";

                _id = value;
            }
        }


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
            return (this.HasChange == "1") || (Properties != null && Properties.Any(x => x.HasDataChanged()));
        }
    }
}
