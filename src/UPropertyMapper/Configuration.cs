using UPropertyMapper.Core.Ioc;
using UPropertyMapper.Core.Mappers.Properties;
using UPropertyMapper.Core.Resolvers;

namespace UPropertyMapper
{
    public static class Configuration
    {
        public static void AddPropertyMapper(int propertyTypeId, IPropertyMapper propertyMapper)
        {
            Resolver.Resolve<IPropertyMapperResolver>().AddPropertyMapper(propertyTypeId, propertyMapper);
        }
    }
}
