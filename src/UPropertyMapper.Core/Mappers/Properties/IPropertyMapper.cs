using UPropertyMapper.Core.Models;
using System;

namespace UPropertyMapper.Core.Mappers.Properties
{
    public interface IPropertyMapper
    {
        object Map(PropertyInfo propertyInfo, Type type);
    }
}
