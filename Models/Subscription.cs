using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Outbound_Message_whatsapp.Models
{
    
        public class Subscription
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public int UserId { get; set; }
            [ForeignKey("UserId")]
            public AppUser AppUser { get; set; }
            [Required]
            public int PlanId { get; set; }
            [ForeignKey("PlanId")]
            public Plan Plan { get; set; }
            public DateTime SubscriptionDate { get; set; } = DateTime.Now;
            public DateTime ExpirationDate { get; set; }
            public string Status { get; set; }
            public ICollection<Invoice> Invoices { get; set; }
        }

    


}

