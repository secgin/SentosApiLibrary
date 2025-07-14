namespace SentosApiLibrary.Abstracts
{
    public interface IResult
    {
        public bool IsSuccess { get; }
        public bool IsFail => !IsSuccess;
        public string Message { get; }
        public string Code { get; }
    }

    public interface IResult<T>: IResult
    {
        public T Data { get; }       
    }

    public interface IPaginationResult<T> : IResult<IEnumerable<T>>
    {
        public int Page { get; }

        public int Size { get; }

        public int TotalElements { get; }

        public int TotalPages { get; }
    }
}
