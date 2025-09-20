namespace Hero.Domain.Abstractions;

public class Result(bool success, string? error = null)
{
    public bool Success {get;} = success;
    public string Error {get;} = error;
    public static Result Ok() => new(true);
    public static Result Fail(string err) => new(false, err);
    public static Result<T> Ok<T>(T value) => new(value, true, string.Empty);
    public static Result<T> Fail<T>(string error) => new(default, false, error);
    public static Result<T> FromValue<T>(T? value) => value != null ? Ok(value) : Fail<T>("Provided value is null");
}

public class Result<T>: Result
{
    public T? Value {get;}
    internal Result(T? value, bool ok, string error)
        :base(ok, error)
    {
        Value = value;
    }
    public static implicit operator Result<T>(T value) => FromValue(value);
    public static implicit operator T?(Result<T> result) => result.Value;
}