namespace DotnetBackendAPI.Filters;

public record UserFilter
(
    string? Name,
    string? Surname,
    string? Number,
    int PageSize = 10,
    int PageNumber = 1
);
