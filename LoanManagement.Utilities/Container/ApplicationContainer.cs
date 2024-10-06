using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace LoanManagement.Platform.Container
{
    public static class ApplicationContainer
    {
        private static IUnityContainer _unityContainer = new UnityContainer();
        
        static ApplicationContainer()
        {
            ((Unity.UnityContainer)_unityContainer).AddExtension(new Unity.Diagnostic());
        }
        public static IUnityContainer GetContainer()
        {
               return _unityContainer;
        }
        public static void RegisterSingleton<TInterface, TClass>()
            where TClass:TInterface
        {
            _unityContainer.RegisterSingleton<TInterface,TClass>();
        }
        public static void RegisterSingleton<TInterface, TClass>(params object[] ctorParameters)
            where TClass : TInterface
        {
            _unityContainer.RegisterSingleton<TInterface, TClass>(new Unity.Injection.InjectionConstructor(ctorParameters));
        }
        public static void RegisterSingleton<TInterface>(TInterface instance) 
        {
            _unityContainer.RegisterInstance<TInterface>(instance);
        }
        public static TInterface Resolve<TInterface>()
        {
            return _unityContainer.Resolve<TInterface>();
        }

    }
}