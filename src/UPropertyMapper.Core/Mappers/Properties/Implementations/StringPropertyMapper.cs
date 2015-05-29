using System;
using UPropertyMapper.Core.Models;

namespace UPropertyMapper.Core.Mappers.Properties.Implementations
{
    public class StringPropertyMapper : IPropertyMapper
    {
        public object Map(PropertyInfo propertyInfo, Type type)
        {
            return propertyInfo.RawValue;
        }
    }
}
