using System;
using Umbraco.Core.Models;
using UPropertyMapper.Core.Models;

namespace UPropertyMapper.Core.Services.Implementations
{
    public class MappedContentService : IMappedContentService
    {
        public T Get<T>(IPublishedContent publishedContent) where T : MappedContent
        {
            return CreateAndMap<T>(publishedContent);
        }

        protected virtual T CreateAndMap<T>(IPublishedContent publishedContent) where T : MappedContent
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            obj.PublishedContent = publishedContent;
            obj.Map();
            return obj;
        }
    }
}
