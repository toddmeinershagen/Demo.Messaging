using System;
using Demo.Messaging.Core.Messages;
using Demo.Messaging.Publisher.App_Start;
using MedAssets.Common.Services.ServiceBus;
using StructureMap;

namespace Demo.Messaging.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            StructureMapConfig.OnApplicationStart();
            var bus = ObjectFactory.GetInstance<IBus>();
            bus.Start();

            while (RequestInput() != "q")
            {
                var message = new PatientBenefitsReceived {PatientId = 12};
                bus.Publish(message);    
            }

            bus.Stop();
        }

        public static string RequestInput()
        {
            Console.WriteLine("Hit enter to submit.  If you type 'Q', then we will quit.");
            return Console.ReadLine();
        }
    }
}
