using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Shared
{
    public class SwanShop : BaseDto
    {
        public List<Configuration> Configs { get; set; }

        public List<SwanShopCategorie> Categories { get; set; }

        public List<SwanShopSubCategorie> SubCategories { get; set; }

        public List<SwanShopArticle> Articles { get; set; }

        public List<SwanShopData> Datas { get; set; }

        public SwanShop() { }
        public SwanShop(bool initAll)
        {
            if (initAll)
            {
                Configs = new List<Configuration>();
                Configs.Add(new Configuration(initAll));

                Categories = new List<SwanShopCategorie>();
                Categories.Add(new SwanShopCategorie(initAll));

                SubCategories = new List<SwanShopSubCategorie>();
                SubCategories.Add(new SwanShopSubCategorie(initAll));

                Articles = new List<SwanShopArticle>();
                Articles.Add(new SwanShopArticle(initAll));

                Datas = new List<SwanShopData>();
                Datas.Add(new SwanShopData(initAll));
            }
        }

        public bool HasDataChanged()
        {
            return (Configs != null && Configs.Any(x => x.HasDataChanged()))
                    || (Categories != null && Categories.Any(x => x.HasDataChanged()))
                    || (SubCategories != null && SubCategories.Any(x => x.HasDataChanged()))
                    || (Articles != null && Articles.Any(x => x.HasDataChanged()))
                    || (Datas != null && Datas.Any(x => x.HasDataChanged()));
        }
    }
}
