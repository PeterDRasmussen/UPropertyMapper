using System;
using System.Collections;
using System.Linq;
using Umbraco.Core.Models;
using UPropertyMapper.Core.Models;
using UPropertyMapper.Core.Resolvers;

namespace UPropertyMapper.Core.Mappers.Content.Implementations
{
    public class ContentAutoMapper : ContentMapperBase, IContentMapper
    {
        public ContentAutoMapper(IPropertyMapperResolver propertyMapperResolver)
            : base(propertyMapperResolver) {}
        
        public T Map<T>(IPublishedContent content, T mappedContent) where T : MappedContent
        {
            foreach (var contentProperty in mappedContent.GetType().GetProperties())
            {
                var umbracoProperty = content.Properties.FirstOrDefault(x => String.Equals(x.PropertyTypeAlias, contentProperty.Name, StringComparison.InvariantCultureIgnoreCase));
                if (umbracoProperty == null)
                    continue;
                MapProperty(new PropertyInfo(umbracoProperty, content.ContentType.GetPropertyType(umbracoProperty.PropertyTypeAlias)), mappedContent);
            }
          
            MapGeneralProperties(content, mappedContent);
            return mappedContent;
        }

        private void MapProperty<T>(PropertyInfo propertyInfo, T mappedContent) where T : MappedContent
        {
            var mappedContentProperty = mappedContent.GetType().GetProperties().FirstOrDefault(x => x.Name.ToLowerInvariant() == propertyInfo.Alias.ToLowerInvariant());
            if (mappedContentProperty == null)
                return;
            
            var propertyMapper = PropertyMapperResolver.Resolve(propertyInfo.DataTypeId) ?? PropertyMapperResolver.Default;
            mappedContentProperty.SetValue(mappedContent, propertyMapper.Map(propertyInfo, mappedContentProperty.PropertyType));
        }
    }
}
