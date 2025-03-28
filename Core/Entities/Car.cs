using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace AutoserviceAPI.Core.Entities
{
    [Table("cars")]
    public class Car : BaseModel
    {
        [PrimaryKey("id")]
        public Guid Id { get; set; }
        [Column("clientid")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; } // Навигационное свойство для клиента
        [Column("make")]
        public string Make { get; set; }
        [Column("model")]
        public string Model { get; set; }
        [Column("year")]
        public int Year { get; set; }
        [Column("licenseplate")]
        public string LicensePlate { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
