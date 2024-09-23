using Microsoft.EntityFrameworkCore;
using PartTimePt.Datas;
using PartTimePt.Models.DatabaseModel;
using PartTimePt.Models.ExampleModel;

namespace PartTimePt.Services;

public class ExampleService : IExampleService
{
    private readonly ApplicationDbContext dbContext;

    public ExampleService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ExampleResponse> ExampleCreateAsync(ExampleCreateRequest request)
    {
        ExampleTable newRecord = new(request);
        dbContext.ExampleTable.Add(newRecord);
        await dbContext.SaveChangesAsync();
        return new()
        {
            Result = newRecord,
            Status = 200,
            Description = "Ok",
        };
    }

    public async Task<ExampleResponse> ExampleReadAsync(long id)
    {
        ExampleTable? getRecord = await dbContext.ExampleTable.FirstOrDefaultAsync(x => x.Id == id);
        if (getRecord == null) return new()
        {
            Result = null,
            Status = 404,
            Description = "Not found",
        };
        return new()
        {
            Result = getRecord,
            Status = 200,
            Description = "Ok",
        };
    }

    public async Task<ExampleResponse> ExampleUpdateAsync(ExampleEditRequest request)
    {
        ExampleTable? getRecord = await dbContext.ExampleTable.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (getRecord == null) return new()
        {
            Result = null,
            Status = 404,
            Description = "Not found",
        };
        getRecord.Update(request);
        await dbContext.SaveChangesAsync();
        return new()
        {
            Result = getRecord,
            Status = 200,
            Description = "Ok",
        };
    }

    public async Task<ExampleResponse> ExampleDeleteAsync(long id)
    {
        ExampleTable? getRecord = await dbContext.ExampleTable.FirstOrDefaultAsync(x => x.Id == id);
        if (getRecord == null) return new()
        {
            Result = null,
            Status = 404,
            Description = "Not found",
        };
        dbContext.ExampleTable.Remove(getRecord);
        await dbContext.SaveChangesAsync();
        return new()
        {
            Result = getRecord,
            Status = 200,
            Description = "Ok",
        };
    }
}

public interface IExampleService
{
    Task<ExampleResponse> ExampleCreateAsync(ExampleCreateRequest request);
    Task<ExampleResponse> ExampleDeleteAsync(long id);
    Task<ExampleResponse> ExampleReadAsync(long id);
    Task<ExampleResponse> ExampleUpdateAsync(ExampleEditRequest request);
}
