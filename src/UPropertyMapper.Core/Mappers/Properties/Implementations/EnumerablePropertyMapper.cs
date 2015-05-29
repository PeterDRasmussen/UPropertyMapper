using System;
using System.Collections;
using System.Collections.Generic;
using Umbraco.Web;
using UPropertyMapper.Core.Mappers.Content;
using UPropertyMapper.Core.Models;

namespace UPropertyMapper.Core.Mappers.Properties.Implementations
{
    public class EnumerablePropertyMapper : IPropertyMapper
    {
        private readonly IContentMapper _contentMapper;
        private readonly UmbracoContext _context;

        public EnumerablePropertyMapper(IContentMapper contentMapper, UmbracoContext context)
        {
            _contentMapper = contentMapper;
            _context = context;
        }

        public object Map(PropertyInfo propertyInfo, Type type)
        {
            if (string.IsNullOrWhiteSpace(propertyInfo.RawValue) || !(typeof(IEnumerable<MappedContent>).IsAssignableFrom(type)))
                return null;

            var listGenericType = type.GetGenericArguments()[0];
            var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(listGenericType));

            foreach (var contentId in propertyInfo.RawValue.Split(','))
            {
                var publishedContent = _context.ContentCache.GetById(Convert.ToInt32(contentId));
                list.Add(_contentMapper.Map(publishedContent, (MappedContent)Activator.CreateInstance(listGenericType)));
            }

            return list;
        }
    }
}