namespace UPropertyMapper.Core.Models
{
    public interface IHaveCommonProperties
    {
        int Id { get; set; }
        string Url { get; set; }
        int Level { get; set; }
    }
}
