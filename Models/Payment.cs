using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Outbound_Message_whatsapp.Data
{
    public partial class ApplicationDbContext
    {
        public class Payment
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public int InvoiceId { get; set; }
            [ForeignKey("InvoiceId")]
            public Invoice Invoice { get; set; }
            public DateTime PaymentDate { get; set; } = DateTime.Now;
            public decimal Amount { get; set; }
            public string PaymentMethod { get; set; }
        }

    }


}

