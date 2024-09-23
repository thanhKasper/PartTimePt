using PartTimePt.Models.ExampleModel;
using System.ComponentModel.DataAnnotations;

namespace PartTimePt.Models.DatabaseModel;

public class ExampleTable
{
    [Key]
    public long Id { get; set; }
    public int NumberA { get; set; } = 0;
    public int NumberB { get; set; } = 0;

    public ExampleTable()
    {

    }

    public ExampleTable(ExampleCreateRequest request)
    {
        NumberA = request.NumberA;
        NumberB = request.NumberB;
    }

    public void Update(ExampleEditRequest request)
    {
        NumberA = request.NumberA;
        NumberB = request.NumberB;
    }
}
