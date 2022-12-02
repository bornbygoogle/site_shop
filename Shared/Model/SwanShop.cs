using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Shared
{
    public class SwanShop : BaseDto
    {
        public List<Configuration> Configs { get; set; }
        public SwanShop() { }
        public SwanShop(bool initAll)
        {
            if (initAll)
            {
                Configs = new List<Configuration>();
                Configs.Add(new Configuration(initAll));
            }
        }

        public bool HasDataChanged()
        {
            return Configs.Any(x => x.HasDataChanged());
        }
    }
}
