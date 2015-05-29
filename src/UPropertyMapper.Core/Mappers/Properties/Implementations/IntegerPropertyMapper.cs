using System;
using UPropertyMapper.Core.Models;

namespace UPropertyMapper.Core.Mappers.Properties.Implementations
{
    public class IntegerPropertyMapper : IPropertyMapper
    {
        public object Map(PropertyInfo propertyInfo, Type type)
        {
            if (string.IsNullOrEmpty(propertyInfo.RawValue))
                return 0;

            return Convert.ToInt32(propertyInfo.RawValue);
        }
    }
}
