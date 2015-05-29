using Umbraco.Core.Models;

namespace UPropertyMapper.Core.Models.PropertyModels
{
    public class Image
    {
        public Image(){}

        public Image(IPublishedContent publishedContent)
        {
            Src = publishedContent.Url;
            Alt = publishedContent.Name;
            PublishedContent = publishedContent;
        }

        public string Src { get; set; }

        public string Alt { get; set; }

        public IPublishedContent PublishedContent { get; set; }
    }
}
