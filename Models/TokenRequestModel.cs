
using System.ComponentModel.DataAnnotations;

namespace Outbound_Message_whatsapp.Models
{
    public class TokenRequestModel
    {

        [Required(ErrorMessage = "Client ID is required.")]
        [RegularExpression(@"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$",
          ErrorMessage = "Invalid Client ID format.")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "Client Secret is required.")]
        [RegularExpression(@"^[A-Za-z0-9_\-]+$",
        ErrorMessage = "Invalid Client Secret format.")]
        public string ClientSecret { get; set; }
    }
}
