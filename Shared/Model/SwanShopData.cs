using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Shared
{
    public class SwanShopData : BaseDto
    {
        private long? _id;

        private long? _articleId;

        private string _type;

        private string _imageUrl;

        private byte[] _imageBlob;

        public long? Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
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

        public byte[] ImageBlob
        {
            get { return _imageBlob; }
            set
            {
                _imageBlob = value;
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

        public SwanShopData() { }

        public SwanShopData(bool initAll)
        {
            if (initAll)
            {

            }
        }

        public bool HasDataChanged()
        {
            return HasChange == "1";
        }
    }
}
