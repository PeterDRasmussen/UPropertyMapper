using System;
using UPropertyMapper.Core.Models;

namespace UPropertyMapper.Core.Mappers.Properties.Implementations
{
    public class BoolPropertyMapper : IPropertyMapper
    {
        public object Map(PropertyInfo propertyInfo, Type type)
        {
            if (type == typeof(bool))
                return propertyInfo.RawValue != "0";
            return propertyInfo.RawValue;
        }
    }
}
