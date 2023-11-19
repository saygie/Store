namespace Store.Models.Results;

public interface IDataResult<T> : IResult
{
    T Data { get; }
}
