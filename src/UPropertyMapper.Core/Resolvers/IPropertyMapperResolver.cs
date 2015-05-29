using UPropertyMapper.Core.Mappers.Properties;

namespace UPropertyMapper.Core.Resolvers
{
    public interface IPropertyMapperResolver
    {
        IPropertyMapper Default { get; set; }

        IPropertyMapper Resolve(int propertyTypeId);

        void AddPropertyMapper(int propertyTypeId, IPropertyMapper propertyMapper);
    }
}
