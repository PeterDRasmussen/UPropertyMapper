using Microsoft.Practices.Unity;

namespace UPropertyMapper.Core.Ioc
{
    public static class Resolver
    {
        internal static IUnityContainer Container { get; set; }

        public static T Resolve<T>()
        {
            if (Container == null)
            {
                Container = new UnityContainer();
                Unity.Module.RegisterTypes(Container); 
            }
            return Container.Resolve<T>();
        }
    }
}
