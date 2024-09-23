using Microsoft.AspNetCore.Mvc;
using PartTimePt.Models.ExampleModel;
using PartTimePt.Services;

namespace PartTimePt.Controllers;
[Route("api/example")]
[ApiController]
public class ExampleController : ControllerBase
{
    private readonly IExampleService exampleService;

    public ExampleController(IExampleService exampleService)
    {
        this.exampleService = exampleService;
    }

    /// <summary>
    /// Example of post
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<ExampleResponse>> CreateExample(ExampleCreateRequest request)
    {
        ExampleResponse response = await exampleService.ExampleCreateAsync(request);
        return StatusCode(response.Status, response);
    }

    /// <summary>
    /// Example of get
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("read")]
    public async Task<ActionResult<ExampleResponse>> ReadExample(long id)
    {
        ExampleResponse response = await exampleService.ExampleReadAsync(id);
        return StatusCode(response.Status, response);
    }

    /// <summary>
    /// Example of put
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("update")]
    public async Task<ActionResult<ExampleResponse>> UpdateExample(ExampleEditRequest request)
    {
        ExampleResponse response = await exampleService.ExampleUpdateAsync(request);
        return StatusCode(response.Status, response);
    }

    /// <summary>
    /// Example of delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult<ExampleResponse>> DeleteExample(long id)
    {
        ExampleResponse response = await exampleService.ExampleDeleteAsync(id);
        return StatusCode(response.Status, response);
    }
}
