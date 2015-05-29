using UPropertyMapper.Core.Models;
using UPropertyMapper.Core.Models.PropertyModels;

namespace TestSite.Models
{
    public class Home : MappedContent
    {
        public string Text { get; set; }

        public int Number { get; set; }
        
        public Image Image { get; set; }

        public Node Content { get; set; }
    }
}