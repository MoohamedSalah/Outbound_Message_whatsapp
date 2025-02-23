using System.ComponentModel.DataAnnotations;

namespace Outbound_Message_whatsapp.Models
{
    
        public class Plan
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            public decimal Price { get; set; }
            [Required]
            public string BillingCycle { get; set; }
            public ICollection<Subscription> Subscriptions { get; set; }
        }

    


}

