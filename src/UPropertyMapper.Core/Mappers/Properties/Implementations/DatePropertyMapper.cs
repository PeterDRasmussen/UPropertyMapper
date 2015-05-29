using System;
using UPropertyMapper.Core.Models;

namespace UPropertyMapper.Core.Mappers.Properties.Implementations
{
    public class DatePropertyMapper : IPropertyMapper
    {
        public object Map(PropertyInfo propertyInfo, Type type)
        {
            if (propertyInfo.RawValue == string.Empty)
                return null;
            return DateTime.Parse(propertyInfo.RawValue);
        }
    }
}
