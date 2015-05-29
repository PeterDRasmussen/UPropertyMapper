using umbraco.interfaces;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace UPropertyMapper.Core.Models
{
    public class PropertyInfo
    {
        public string Alias { get; set; }
        public string RawValue { get; set; }
        public int DataTypeId { get; set; }

        public System.Type ToPropertyType { get; set; }

        public PropertyInfo(IPublishedProperty publishedProperty, PublishedPropertyType publishedPropertyType)
        {
            Map(publishedProperty.PropertyTypeAlias, (string)publishedProperty.DataValue, publishedPropertyType.DataTypeId);
        }

        public PropertyInfo(IProperty property, PropertyType publishedPropertyType)
        {
            Map(property.Alias, property.Value, publishedPropertyType.Id);
        }

        private void Map(string alias, string rawValue, int dataTypeId)
        {
            Alias = alias;
            RawValue = rawValue;
            DataTypeId = dataTypeId;
        }
    }
}