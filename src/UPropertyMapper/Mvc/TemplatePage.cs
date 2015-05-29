using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using UPropertyMapper.Core.Ioc;
using UPropertyMapper.Core.Models;
using UPropertyMapper.Core.Services;

namespace UPropertyMapper.Mvc
{
    public class TemplatePage<T> : UmbracoTemplatePage where T : MappedContent
    {
        private readonly IMappedContentService _mappedContentService;
        public T MappedPage { get { return GetMappedContent<T>(Model.Content); } }

        public TemplatePage() : this(Resolver.Resolve<IMappedContentService>()) {} 

        public TemplatePage(IMappedContentService mappedContentService)
        {
            _mappedContentService = mappedContentService;
        }

        public override void Execute(){}

        public TK GetMappedContent<TK>(IPublishedContent content) where TK : MappedContent
        {
            return _mappedContentService.Get<TK>(content);
        }
    }
}
