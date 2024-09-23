using AspNetExample.Models.TestModel;
using AspNetExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetExample.Controllers;

[Route("api/test")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ITestService testService;
    private readonly IConfiguration configuration;

    public TestController(ITestService testService, IConfiguration configuration)
    {
        this.testService = testService;
        this.configuration = configuration;
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<TestResponse>> TestCreate(TestRequest request)
    {
        TestResponse result = await testService.TestCreate(request);
        return StatusCode(result.Status, result);
    }
}
