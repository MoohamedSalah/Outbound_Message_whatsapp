using Newtonsoft.Json;

namespace Outbound_Message_whatsapp.Models
{

    public class VMData
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
    }
    public class whatsAppData
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
    }
    public class ResponseData
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
    }


    public class Library
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
    }
    public class WhatsAppResponse
    {
        public List<whatsAppData> Entities { get; set; } = new();
    }

    public class librariesResponse
    {
        public List<VMData> Entities { get; set; } = new();
    }

    public class responsesResponse
    {
        public List<ResponseData> Entities { get; set; } = new();
    }

    public class AgentlessMessageResponse
    {
        [JsonProperty("conversationId")]
        public string ConversationId { get; set; }
    }


}
