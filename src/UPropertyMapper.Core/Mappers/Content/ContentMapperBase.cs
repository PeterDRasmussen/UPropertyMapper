using Umbraco.Core.Models;
using UPropertyMapper.Core.Models;
using UPropertyMapper.Core.Resolvers;

namespace UPropertyMapper.Core.Mappers.Content
{
    public abstract class ContentMapperBase
    {
        protected readonly IPropertyMapperResolver PropertyMapperResolver;

        protected ContentMapperBase(IPropertyMapperResolver propertyMapperResolver)
        {
            PropertyMapperResolver = propertyMapperResolver;
        }

        protected void MapGeneralProperties(IPublishedContent content, MappedContent mappedContent)
        {
            mappedContent.Id = content.Id;
            mappedContent.Url = content.Url;
            mappedContent.Level = content.Level;
        }
    }
}
