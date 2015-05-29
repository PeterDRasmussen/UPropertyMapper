using System;

namespace UPropertyMapper.Core.Resolvers.Exceptions
{
    public class PropertyMapperNotFoundException : NullReferenceException
    {
        public PropertyMapperNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public PropertyMapperNotFoundException(string message) : base(message)
        {
        }
    }
}
