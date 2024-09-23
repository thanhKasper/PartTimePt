using AspNetExample.Models.DatabaseModel;

namespace AspNetExample.Models.TestModel;

public class TestResponse : BaseResponse
{
    public TestTable? TestResult { get; set; }
}
