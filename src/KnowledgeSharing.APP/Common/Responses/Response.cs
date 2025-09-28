namespace KnowledgeSharing.APP.Common.DTOs.Responses;

public sealed class Response<TObject>
{
    public bool IsSuccess { get; }
    public TObject? Data { get; }
    public IEnumerable<ValidationErrorDto> Errors { get; }

    private Response(bool isSuccess, TObject? data, IEnumerable<ValidationErrorDto>? errors = null)
    {
        IsSuccess = isSuccess;
        Data = data;
        Errors = errors?.ToArray() ?? Array.Empty<ValidationErrorDto>();
    }

    public static Response<TObject> Success(TObject data) => new(true, data);
    public static Response<TObject> Failure(ValidationErrorDto error) => new(false, default, new[] { error });
    public static Response<TObject> Failure(IEnumerable<ValidationErrorDto> errors) => new(false, default, errors ?? throw new ArgumentNullException(nameof(errors)));
}