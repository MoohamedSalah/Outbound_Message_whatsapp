using System.ComponentModel.DataAnnotations;

namespace Outbound_Message_whatsapp.Data
{
    public partial class ApplicationDbContext
    {
        // Define the entities
        public class AppUser
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
            [Required]
            public string Name { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
            public DateTime UpdatedAt { get; set; } = DateTime.Now;
            public ICollection<Subscription> Subscriptions { get; set; }
            public ICollection<Invoice> Invoices { get; set; }
        }

    }


}

