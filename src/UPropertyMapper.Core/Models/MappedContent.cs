using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using UPropertyMapper.Core.Ioc;
using UPropertyMapper.Core.Mappers.Content;
using UPropertyMapper.Core.Services;

namespace UPropertyMapper.Core.Models
{
    public abstract class MappedContent : IHaveCommonProperties
    {
        public IPublishedContent PublishedContent;
        protected IContentMapper ContentMapper;
        protected IMappedContentService MappedContentService;

        public int Id { get; set; }
        public string Url { get; set; }
        public int Level { get; set; }

        protected MappedContent()
        {
            ResolveServices();
        }

        protected MappedContent(IPublishedContent publishedContent) : this()
        {
            PublishedContent = publishedContent;
            Map();
        }

        protected MappedContent(IPublishedContent publishedContent, IContentMapper contentMapper, IMappedContentService mappedContentService) 
        {
            PublishedContent = publishedContent;
            ContentMapper = contentMapper;
            MappedContentService = mappedContentService;

            Map();
        }

        public virtual T GetParent<T>() where T : MappedContent
        {
            return MappedContentService.Get<T>(PublishedContent.Parent);
        }

        public virtual IEnumerable<T> GetChildren<T>() where T : MappedContent
        {
            return PublishedContent.Children.Select(x => MappedContentService.Get<T>(x));
        }

        internal void Map()
        {
            if (ContentMapper == null || PublishedContent == null)
                return;

            var method = ContentMapper.GetType().GetMethod("Map");
            var generic = method.MakeGenericMethod(GetType());
            generic.Invoke(ContentMapper, new object[] { PublishedContent, this });
        }

        private void ResolveServices()
        {
            ContentMapper = Resolver.Resolve<IContentMapper>();
            MappedContentService = Resolver.Resolve<IMappedContentService>();
        }
    }
}
