using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Shared
{
    public class SwanShopData : BaseDto
    {
        private string _route;
        private string _idInsideRoute;
        private string _imageUrl;
        private byte[] _imageBlob;
        private string _title;
        private string _subTitle;
        private string _text;
        private decimal? _price;
        private string _categorie;
        private string _isMonthCategorie;

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
        public string IdInsideRoute
        {
            get
            {
                return _idInsideRoute;
            }
            set
            {
                if (_idInsideRoute != null && value != null && _idInsideRoute != value)
                    this.HasChange = "1";

                _idInsideRoute = value;
            }
        }
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                if (_imageUrl != null && value != null && _imageUrl != value)
                    this.HasChange = "1";

                _imageUrl = value;
            }
        }
        public byte[] ImageBlob
        {
            get { return _imageBlob; }
            set
            {
                if (_imageBlob != null && value != null && _imageBlob != value)
                    this.HasChange = "1";

                _imageBlob = value;
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != null && value != null && _title != value)
                    this.HasChange = "1";

                _title = value;
            }
        }
        public string SubTitle
        {
            get { return _subTitle; }
            set
            {
                if (_subTitle != null && value != null && _subTitle != value)
                    this.HasChange = "1";

                _subTitle = value;
            }
        }
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != null && value != null && _text != value)
                    this.HasChange = "1";

                _text = value;
            }
        }
        public decimal? Price
        {
            get { return _price; }
            set
            {
                if (_price != null && value != null && _price != value)
                    this.HasChange = "1";

                _price = value;
            }
        }
        public string Categorie
        {
            get { return _categorie; }
            set
            {
                if (_categorie != null && value != null && _categorie != value)
                    this.HasChange = "1";

                _categorie = value;
            }
        }

        public string IsMonthCategorie
        {
            get { return _isMonthCategorie; }
            set
            {
                if (_isMonthCategorie != null && value != null && _isMonthCategorie != value)
                    this.HasChange = "1";

                _isMonthCategorie = value;
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
            return this.HasChange == "1";
        }
    }
}
