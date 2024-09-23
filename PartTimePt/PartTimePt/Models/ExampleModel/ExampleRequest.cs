namespace PartTimePt.Models.ExampleModel;

public class ExampleCreateRequest
{
    public int NumberA { get; set; } = -1;
    public int NumberB { get; set; } = -1;
}

public class ExampleEditRequest
{
    public long Id { get; set; } = -1;
    public int NumberA { get; set; } = -1;
    public int NumberB { get; set; } = -1;
}
