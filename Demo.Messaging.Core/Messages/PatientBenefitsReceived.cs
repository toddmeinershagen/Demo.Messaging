namespace Demo.Messaging.Core.Messages
{
    public class PatientBenefitsReceived : IPatientBenefitsReceived
    {
        public int PatientId { get; set; }
    }
}
