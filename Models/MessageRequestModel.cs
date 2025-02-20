namespace Outbound_Message_whatsapp.Models
{
    public class MessageRequestModel
    {
        public string ToAddressMessengerType { get; set; } = "whatsapp";
        public string ToAddress { get; set; } = "";
        public string fromAddress { get; set; } = "";
        public string responseId { get; set; } = "";
    }
}
