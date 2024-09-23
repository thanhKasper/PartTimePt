using AspNetExample.Datas;
using AspNetExample.Models.DatabaseModel;
using AspNetExample.Models.TestModel;

namespace AspNetExample.Services;

public class TestService : ITestService
{
    private readonly ApplicationDbContext dbContext;

    public TestService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<TestResponse> TestCreate(TestRequest request)
    {
        TestTable newTable = new(request);
        await dbContext.TestTable.AddAsync(newTable);
        await dbContext.SaveChangesAsync();
        return new TestResponse()
        {
            Status = 200,
            Description = "Ok",
            TestResult = newTable,
        };
    }
}

public interface ITestService
{
    Task<TestResponse> TestCreate(TestRequest request);
}
