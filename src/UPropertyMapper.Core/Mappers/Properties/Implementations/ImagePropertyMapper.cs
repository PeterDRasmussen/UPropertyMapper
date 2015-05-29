using System;
using Umbraco.Core.Models;
using Umbraco.Web;
using UPropertyMapper.Core.Models;
using UPropertyMapper.Core.Models.PropertyModels;

namespace UPropertyMapper.Core.Mappers.Properties.Implementations
{
    public class ImagePropertyMapper : IPropertyMapper
    {
        private readonly UmbracoHelper _umbracoHelper;

        public ImagePropertyMapper(UmbracoHelper umbracoHelper)
        {
            _umbracoHelper = umbracoHelper;
        }

        public object Map(PropertyInfo propertyInfo, Type type)
        {
            if (string.IsNullOrWhiteSpace(propertyInfo.RawValue))
                return null;
            if (type == typeof (Image))
                return new Image(_umbracoHelper.TypedMedia(Convert.ToInt32(propertyInfo.RawValue)));
            if (type == typeof(IPublishedContent))
                return _umbracoHelper.TypedMedia(Convert.ToInt32(propertyInfo.RawValue));
            if (type == typeof (Int32))
                return Convert.ToInt32(propertyInfo.RawValue);
            return propertyInfo.RawValue;
        }
    }
}
