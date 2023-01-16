using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Shared
{
    public class Configuration : BaseDto
    {
        private long? _id;

        private string _route;

        private string _identification;

        private string _propertyName;
        private string _propertyValue;


        public long? Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string? Route
        {
            get { return _route; }
            set
            {
                _route = value;
            }
        }

        public string? Identification
        {
            get { return _identification; }
            set
            {
                _identification = value;
            }
        }

        public string? PropertyName
        {
            get { return _propertyName; }
            set
            {
                _propertyName = value;
            }
        }
        public string? PropertyValue
        {
            get { return _propertyValue; }
            set
            {
                _propertyValue = value;
            }
        }

        public Configuration() { }
        public Configuration(bool initAll)
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
