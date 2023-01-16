using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Shared
{
    public class SwanShopImage : BaseDto
    {
        private long? _id;

        private long? _configId;
        private long? _articleId;

        private string _imageUrl;

        public long? Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public long? ConfigId
        {
            get { return _configId; }
            set
            {
                _configId = value;
            }
        }

        public long? ArticleId
        {
            get { return _articleId; }
            set
            {
                _articleId = value;
            }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
            }
        }

        public SwanShopImage() { }

        public SwanShopImage(bool initAll)
        {
            if (initAll)
            {

            }
        }

        public bool HasDataChanged()
        {
            return HasChange == "1";
        }

        public void ClearAllChanges()
        {
            this.HasChange = null;
        }
    }
}
