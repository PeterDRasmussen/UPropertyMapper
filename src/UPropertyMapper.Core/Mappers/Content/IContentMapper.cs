using Umbraco.Core.Models;
using UPropertyMapper.Core.Models;

namespace UPropertyMapper.Core.Mappers.Content
{
    public interface IContentMapper
    {
        T Map<T>(IPublishedContent content, T mappedContent) where T : MappedContent;
    }
}
