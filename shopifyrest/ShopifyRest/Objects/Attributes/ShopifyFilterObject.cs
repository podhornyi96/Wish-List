using System;

namespace ShopifyRest.Objects.Attributes
{
    /// <summary>
    /// Attribute that stores original name of filter
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class ShopifyFilterObject : Attribute
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ShopifyFilterObject(string name)
        {
            this._name = name;
        }
    }
}
