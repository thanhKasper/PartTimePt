namespace AspNetExample.Models;

public class BaseResponse
{
    public int Status { get; set; } = -1;
    public string Description { get; set; } = string.Empty;
}

