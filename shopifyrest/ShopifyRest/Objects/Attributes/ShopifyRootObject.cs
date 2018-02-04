using System;

namespace ShopifyRest.Objects.Attributes
{
    /// <summary>
    /// Attribute that stores root object name
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class ShopifyRootObject : Attribute
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ShopifyRootObject(string name)
        {
            this._name = name;
        }

    }
}
