using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace ChatGPT.ASP.NET.Integration.Controllers;

[Route("bot/[controller]")]
public class ChatGptController(OpenAIAPI chatGpt) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Chat([FromQuery(Name = "prompt")] string prompt)
    {
        var response = "";

        var completion = new CompletionRequest
        {
            Prompt = prompt,
            Model = Model.Davinci,
            MaxTokens = 200
        };

        var result = await chatGpt.Completions.CreateCompletionAsync(completion);
        result.Completions.ForEach(resultText => response = resultText.Text);

        return Ok(response);
    }
}
