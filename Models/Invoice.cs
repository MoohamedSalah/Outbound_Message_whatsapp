using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Outbound_Message_whatsapp.Models
{
   
        public class Invoice
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public int UserId { get; set; }
            [ForeignKey("UserId")]
            public AppUser AppUser { get; set; }
            [Required]
            public int SubscriptionId { get; set; }
            [ForeignKey("SubscriptionId")]
            public Subscription Subscription { get; set; }
            public DateTime InvoiceDate { get; set; } = DateTime.Now;
            public DateTime DueDate { get; set; }
            public decimal Amount { get; set; }
            public string Status { get; set; }
            public ICollection<Payment> Payments { get; set; }
        }

    


}

