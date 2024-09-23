using AspNetExample.Models.TestModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetExample.Models.DatabaseModel;

public class TestTable
{
    [Key]
    public long Id { get; set; }
    public int NumberA { get; set; } = 0;
    public int NumberB { get; set; } = 0;

    public TestTable()
    {

    }

    public TestTable(TestRequest request)
    {
        NumberA = request.NumberA;
        NumberB = request.NumberB;
    }
}
