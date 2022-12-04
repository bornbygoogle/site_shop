using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Shared
{
    public class SwanShop : BaseDto
    {
        public List<Configuration> Configs { get; set; }

        public List<SwanShopData> Datas { get; set; }

        public SwanShop() { }
        public SwanShop(bool initAll)
        {
            if (initAll)
            {
                Configs = new List<Configuration>();
                Configs.Add(new Configuration(initAll));

                Datas = new List<SwanShopData>();
                Datas.Add(new SwanShopData(initAll));
            }
        }

        public bool HasDataChanged()
        {
            return (Configs != null && Configs.Any(x => x.HasDataChanged())) || (Datas != null && Datas.Any(x => x.HasDataChanged()));
        }
    }
}
