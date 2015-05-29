using UPropertyMapper.Core.Services;

namespace UPropertyMapper.Mvc.Controllers
{
    public class SurfaceController : Umbraco.Web.Mvc.SurfaceController
    {
        public readonly IMappedContentService MappedContentService;

        public SurfaceController(IMappedContentService mappedContentService)
        {
            MappedContentService = mappedContentService;
        }

        protected SurfaceController() : this (Core.Ioc.Resolver.Resolve<IMappedContentService>()) {}
    }
}
