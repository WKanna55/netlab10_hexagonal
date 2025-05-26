using Lab10_wkana.Application.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab10_wkana.Persistense.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponsesController : ControllerBase
{
    private readonly IResponseService _responseService;

    public ResponsesController(IResponseService responseService)
    {
        _responseService = responseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllResponses()
    {
        var responses = await _responseService.GetAllResponsesAsync();
        return Ok(responses);
    }

}