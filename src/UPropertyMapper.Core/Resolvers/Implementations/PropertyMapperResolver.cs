using System;
using System.Collections.Generic;
using UPropertyMapper.Core.Mappers.Properties;
using UPropertyMapper.Core.Resolvers.Exceptions;

namespace UPropertyMapper.Core.Resolvers.Implementations
{
    public class PropertyMapperResolver : IPropertyMapperResolver
    {
        public IPropertyMapper Default { get; set; }

        public IPropertyMapper Resolve(int propertyTypeId)
        {
            IPropertyMapper mapper;
            try
            {
                mapper = PropertyMappers.Container[propertyTypeId];
            }
            catch (KeyNotFoundException)
            {
                throw new PropertyMapperNotFoundException(string.Format("No IPropertyMapper with the ID {0} was found",
                        propertyTypeId));
            }

            return mapper;
        }

        public void AddPropertyMapper(int propertyTypeId, IPropertyMapper propertyMapper)
        {
            PropertyMappers.Container[propertyTypeId] = propertyMapper;
        }
    }
}
