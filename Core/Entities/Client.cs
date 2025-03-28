using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace AutoserviceAPI.Core.Entities
{
    [Table("clients")]
    public class Client : BaseModel
    {
        [PrimaryKey("id")]
        public Guid Id { get; set; }
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
        [Column("phonenumber")]
        public string PhoneNumber { get; set; }
        [Column("email")]
        public string Email { get; set; }

        // Навигационные свойства
        public ICollection<Car> Cars { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
