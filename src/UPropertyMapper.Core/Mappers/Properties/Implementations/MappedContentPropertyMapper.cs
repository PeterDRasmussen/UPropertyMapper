using System;
using Umbraco.Web;
using UPropertyMapper.Core.Mappers.Content;
using UPropertyMapper.Core.Models;

namespace UPropertyMapper.Core.Mappers.Properties.Implementations
{
    public class MappedContentPropertyMapper : IPropertyMapper
    {
        private readonly IContentMapper _contentMapper;
        private readonly UmbracoContext _context;

        public MappedContentPropertyMapper(IContentMapper contentMapper, UmbracoContext context)
        {
            _contentMapper = contentMapper;
            _context = context;
        }

        public object Map(PropertyInfo propertyInfo, Type type)
        {
            if (string.IsNullOrWhiteSpace(propertyInfo.RawValue) || (type != typeof(MappedContent) && !type.IsSubclassOf(typeof(MappedContent))))
                return null;

            var publishedContent = _context.ContentCache.GetById(Convert.ToInt32(propertyInfo.RawValue));

            return _contentMapper.Map(publishedContent, (MappedContent)Activator.CreateInstance(type));
        }
    }
}
