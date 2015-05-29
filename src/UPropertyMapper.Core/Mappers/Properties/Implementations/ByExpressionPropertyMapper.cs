using System;
using UPropertyMapper.Core.Models;

namespace UPropertyMapper.Core.Mappers.Properties.Implementations
{
    public class ByExpressionPropertyMapper : IPropertyMapper
    {
        private readonly Func<string, Type, object> _function;

        public ByExpressionPropertyMapper(Func<string,Type, object> function)
        {
            _function = function;
        }

        public object Map(PropertyInfo propertyInfo, Type type)
        {
            return _function.Invoke(propertyInfo.RawValue, type);
        }
    }
}
