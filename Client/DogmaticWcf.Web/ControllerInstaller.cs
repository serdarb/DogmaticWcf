using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DogmaticWcf.Web.Controllers;

namespace DogmaticWcf.Web
{
    public class ControllerInstaller
    {
        public class ControllersInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(AllTypes.FromThisAssembly()
                                    .Pick().If(Component.IsInSameNamespaceAs<HomeController>())
                                    .If(t => t.Name.EndsWith("Controller"))
                                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                                    .LifestylePerWebRequest());
            }
        } 
    }
}