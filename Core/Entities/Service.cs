namespace AutoserviceAPI.Core.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Связка с записями на обслуживание
        public ICollection<Appointment> Appointments { get; set; }
    }
}
