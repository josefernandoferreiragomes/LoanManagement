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
        
        public static IUnityContainer GetContainer()
        {
               return _unityContainer;
        }

    }
}