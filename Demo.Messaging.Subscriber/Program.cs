using System;
using Demo.Messaging.Subscriber.App_Start;
using MedAssets.Common.Services.ServiceBus;
using StructureMap;

namespace Demo.Messaging.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            StructureMapConfig.OnApplicationStart();
            var bus = ObjectFactory.GetInstance<IBus>();
            bus.Start();

            Console.ReadLine();
                
            bus.Stop();
        }
    }
}
