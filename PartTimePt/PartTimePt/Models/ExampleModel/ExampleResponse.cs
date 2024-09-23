using PartTimePt.Models.DatabaseModel;

namespace PartTimePt.Models.ExampleModel;

public class ExampleResponse : BaseResponse
{
    public ExampleTable? Result { get; set; }
}
