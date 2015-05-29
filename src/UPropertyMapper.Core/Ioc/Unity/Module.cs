using Microsoft.Practices.Unity;
using Umbraco.Web;
using UPropertyMapper.Core.Mappers.Content;
using UPropertyMapper.Core.Mappers.Content.Implementations;
using UPropertyMapper.Core.Mappers.Properties.Implementations;
using UPropertyMapper.Core.Resolvers;
using UPropertyMapper.Core.Resolvers.Implementations;
using UPropertyMapper.Core.Services;
using UPropertyMapper.Core.Services.Implementations;

namespace UPropertyMapper.Core.Ioc.Unity
{
    public static class Module 
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            //Umbraco
            container.RegisterType<UmbracoContext>(
            new ContainerControlledLifetimeManager(),
            new InjectionFactory(c => UmbracoContext.Current));

            //Content Mappers
            container.RegisterType<IContentMapper, ContentAutoMapper>();

            //Resolvers
            container.RegisterType<IPropertyMapperResolver, PropertyMapperResolver>(new ContainerControlledLifetimeManager());
            
            //Services
            container.RegisterType<IMappedContentService, MappedContentService>();
            
            //Property Mappers
            var pmr = container.Resolve<IPropertyMapperResolver>();
            pmr.Default = new StringPropertyMapper();

            
            pmr.AddPropertyMapper(-41, new DatePropertyMapper()); //DateTime
            pmr.AddPropertyMapper(-49, new BoolPropertyMapper()); //TrueFalse
            pmr.AddPropertyMapper(-51, new IntegerPropertyMapper()); //Numeric
            pmr.AddPropertyMapper(-88, new StringPropertyMapper()); //Textstring
            pmr.AddPropertyMapper(-87, new StringPropertyMapper()); //RichText
            pmr.AddPropertyMapper(1035, new ImagePropertyMapper(new UmbracoHelper(container.Resolve<UmbracoContext>()))); //Image
            pmr.AddPropertyMapper(1034, new MappedContentPropertyMapper(container.Resolve<IContentMapper>(), container.Resolve<UmbracoContext>())); //IPublishedContent
        }
    }
}
