namespace KnowledgeSharing.APP.Common.DTOs.Responses;

public sealed record ValidationErrorDto(string Property, string Message, object? AttemptedValue);
