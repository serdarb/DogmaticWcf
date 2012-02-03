using System.ServiceModel;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DogmaticWcf.Server.Contracts;

namespace DogmaticWcf.Web
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<WcfFacility>();
            container.Register(
                Component.For<IMyService>()
                    .AsWcfClient(
                        new DefaultClientModel
                            {
                                Endpoint = WcfEndpoint.BoundTo(new NetNamedPipeBinding())
                                    .At("net.pipe://localhost/MyService")
                            }
                    )
                    .LifeStyle.PerWebRequest);

        }
    }
}