using Microsoft.AspNetCore.Mvc;
using Outbound_Message_whatsapp.Models;
using RestSharp;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Outbound_Message_whatsapp.Controllers.API
{
    [ApiController]
    [Route("api/Data")]
    public class DataController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public DataController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("integrationswhatsapp")]
        public async Task<IActionResult> GetWhatsAppIntegrations()
        {
            if (string.IsNullOrEmpty(TokenStorage.Token))
            {
                return Unauthorized("Access token is missing.");
            }

            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.mec1.pure.cloud/api/v2/conversations/messaging/integrations/whatsapp");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", TokenStorage.Token);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<WhatsAppResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return Ok(data?.Entities);
        }


        [HttpGet("libraries")]
        public async Task<IActionResult> GetLibraries()
        {
            try
            {
                // Get token from your storage or authentication system
                string token = TokenStorage.Token; // Ensure TokenStorage is correctly storing the token

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Access token is missing.");
                }

                // Configure request
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.mec1.pure.cloud/api/v2/responsemanagement/libraries");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Send request
                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
                }

                // Parse JSON response
                var responseContent = await response.Content.ReadAsStringAsync();
                var libraries = JsonSerializer.Deserialize<librariesResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(libraries?.Entities);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"❌ HTTP Request Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Unexpected Error: {ex.Message}");
            }
        }
        [HttpGet("responses")]
        public async Task<IActionResult> GetResponses([FromQuery] string libraryId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenStorage.Token);

            var response = await _httpClient.GetAsync($"https://api.mec1.pure.cloud/api/v2/responsemanagement/responses?libraryId={libraryId}");

            if (response.IsSuccessStatusCode)
            {

                var responseContent = await response.Content.ReadAsStringAsync();
                var responses = JsonSerializer.Deserialize<responsesResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(responses?.Entities);
            }

            return BadRequest(await response.Content.ReadAsStringAsync());
        }


    }

}
