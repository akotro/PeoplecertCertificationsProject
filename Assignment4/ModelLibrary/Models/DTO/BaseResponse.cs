using System.Text.Json.Serialization;

namespace ModelLibrary.Models.DTO;

public class BaseResponse<T> where T : class
{
    public string RequestId { get; set; }
    public bool Success { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }

    public T? Data { get; set; }
}
