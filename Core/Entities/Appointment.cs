namespace AutoserviceAPI.Core.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; } // Навигационное свойство для клиента
        public Guid CarId { get; set; }
        public Car Car { get; set; } // Навигационное свойство для автомобиля
        public Guid ServiceId { get; set; }
        public Service Service { get; set; } // Навигационное свойство для услуги
        public DateTime AppointmentDate { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}
