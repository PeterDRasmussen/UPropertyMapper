using System.Collections.Generic;
using UPropertyMapper.Core.Mappers.Properties;

namespace UPropertyMapper.Core.Resolvers
{
    internal static class PropertyMappers
    {
        public static Dictionary<int, IPropertyMapper> Container = new Dictionary<int, IPropertyMapper>();
    }
}
