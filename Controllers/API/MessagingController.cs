using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Outbound_Message_whatsapp.Models;
using System.Net.Http.Headers;
using System.Text;

[ApiController]
[Route("api/messaging")]
public class MessagingController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public MessagingController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpPost("send-test")]
    public async Task<IActionResult> SendTestMessage([FromBody] MessageRequestModel request)
    {
        var payload = new
        {
            toAddressMessengerType = request.ToAddressMessengerType,
            toAddress = request.ToAddress,
            fromAddress = request.fromAddress,
            messagingTemplate = new { responseId = request.responseId }
        };

        var jsonPayload = JsonConvert.SerializeObject(payload);
        var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenStorage.Token);
        

        var response = await _httpClient.PostAsync("https://api.mec1.pure.cloud/api/v2/conversations/messages/agentless", httpContent);
        var jsonResponse = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // Deserialize the response to extract conversationId
            var responseObject = JsonConvert.DeserializeObject<AgentlessMessageResponse>(jsonResponse);

            return Ok("Message sent successfully Conversation ID:"+responseObject?.ConversationId);
        }

        return BadRequest(await response.Content.ReadAsStringAsync());
    }
}
