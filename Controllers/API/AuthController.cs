using Microsoft.AspNetCore.Mvc;
using Outbound_Message_whatsapp.Models;
using RestSharp;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Outbound_Message_whatsapp.Controllers.API
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody] TokenRequestModel model)
        {
            if (string.IsNullOrEmpty(model.ClientId) || string.IsNullOrEmpty(model.ClientSecret))
            {
                return BadRequest("Client ID and Client Secret are required.");
            }

            string credentials = $"{model.ClientId}:{model.ClientSecret}";
            string base64Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));

            var options = new RestClientOptions("https://login.mec1.pure.cloud")
            {
                MaxTimeout = -1
            };

            var client = new RestClient(options);
            var request = new RestRequest("/oauth/token", Method.Post);
            request.AddHeader("Authorization", $"Basic {base64Credentials}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");

            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                return BadRequest(response.Content);
            }
            string responseText = response.Content;
            var tokenData = JsonSerializer.Deserialize<TokenResponse>(responseText);
            var Token = tokenData?.AccessToken ?? "Failed to retrieve token";

            return Ok(Token);
        }
    }

}
