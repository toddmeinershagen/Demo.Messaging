using System;
using Demo.Messaging.Core;
using MassTransit;

namespace Demo.Messaging.Subscriber
{
    public class Consumer : Consumes<IPatientBenefitsReceived>.All
    {
        public void Consume(IPatientBenefitsReceived message)
        {
            Console.WriteLine("Received benefits for patient id {0}.", message.PatientId);
        }
    }
}
