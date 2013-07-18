using MassTransit;
using MedAssets.Common.Services.ServiceBus;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Demo.Messaging.Publisher.App_Start
{
    public class StructureMapConfig
    {
        public static void OnApplicationStart()
        {
            ObjectFactory.Initialize(x => x.AddRegistry<ObjectRegistry>());
        }
    }

    public class ObjectRegistry : Registry
    {
        public ObjectRegistry()
        {
            Scan(scanner =>
                {
                    scanner.AssembliesFromApplicationBaseDirectory(a => a.FullName.StartsWith("MedAssets"));
                    scanner.LookForRegistries();
                    scanner.SingleImplementationsOfInterface();
                    scanner.WithDefaultConventions();
                });

            For<IBus>()
                .Singleton()
                .Use(() => new MedAssets.Common.Services.ServiceBus.MassTransit.Bus(CreateBus));
        }

        public IServiceBus CreateBus()
        {
            const string uriString = "rabbitmq://localhost/Demo.Messaging.Publisher";
            return ServiceBusFactory.New(bus =>
            {
                bus.UseRabbitMq();
                bus.ReceiveFrom(uriString);
            });
        }
    }
}
