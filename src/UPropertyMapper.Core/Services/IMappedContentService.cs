using Umbraco.Core.Models;
using UPropertyMapper.Core.Models;

namespace UPropertyMapper.Core.Services
{
    public interface IMappedContentService
    {
        T Get<T>(IPublishedContent publishedContent) where T : MappedContent;
    }
}
