using System.Linq;
using System.ServiceModel;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace DogmaticWcf.Server.Application
{
    public class Bootstrapper
    {
        public static IWindsorContainer Container { get; private set; }

        public static void Initialize()
        {
            Container = new WindsorContainer();

            Container.AddFacility<WcfFacility>();

            Container.Register(
                AllTypes.FromAssemblyNamed("DogmaticWcf.Server.Services")
                .Pick().If(type => type.GetInterfaces().Any(i => i.IsDefined(typeof(ServiceContractAttribute), true)))
                .Configure(configurer => configurer
                    .Named(configurer.Implementation.Name)
                    .LifeStyle.PerWcfOperation()
                    .AsWcfService(
                        new DefaultServiceModel()
                            .AddEndpoints(
                                WcfEndpoint.BoundTo(new NetTcpBinding { PortSharingEnabled = true }).At(string.Format("net.tcp://localhost:6969/{0}", configurer.Implementation.Name)),
                                WcfEndpoint.BoundTo(new NetNamedPipeBinding()).At(string.Format("net.pipe://localhost/{0}", configurer.Implementation.Name)))
                            .PublishMetadata()
                    )
                )
                .WithService.Select((type, baseTypes) => type.GetInterfaces().Where(i => i.IsDefined(typeof(ServiceContractAttribute), true)))
            );
        }
    }
}