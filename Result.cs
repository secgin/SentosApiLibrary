using SentosApiLibrary.Abstracts;

namespace SentosApiLibrary
{

    internal class Result : IResult
    {
        private readonly bool _success;

        private readonly string _code;

        private readonly string _message;

        public bool IsSuccess => _success;

        public string Message => _message;

        public string Code => _code;

        protected Result(bool success, string? code, string? message)
        {
            _success = success;
            _code = code ?? string.Empty;
            _message = message ?? string.Empty;
        }

        public static IResult Success(string? code = null, string? message = null)
        {
            return new Result(true, code, message);
        }

        public static IResult Fail(string? code = null, string? message = null)
        {
            return new Result(false, code, message);
        }

        public static IResult FromResult(IResult result)
        {
            if (result.IsSuccess)
                return result;

            return Result.Success(result.Code, result.Message);
        }
    }

    internal class Result<T> : IResult<T>
    {
        private readonly bool _success;

        private readonly string _code;

        private readonly string _message;

        private readonly T _data;

        public T Data => _data;

        public bool IsSuccess => _success;

        public string Message => _message;

        public string Code => _code;

        protected Result(bool success, string? code, string? message)
        {
            _success = success;
            _code = code ?? string.Empty;
            _message = message ?? string.Empty;
            _data = default!;
        }

        protected Result(bool success, T data, string? code, string? message) : this(success, code, message)
        {
            _data = data;
        }

        public static IResult<T> Success(T data, string? code = null, string? message = null)
        {
            return new Result<T>(true, data, code, message);
        }

        public static IResult<T> Fail(string? code = null, string? message = null)
        {
            return new Result<T>(false, code, message);
        }

        public static IResult<T> FromResult<S>(IResult<S> result, T data)
        {
            if (result.IsSuccess)
                return (IResult<T>)result;

            return Result<T>.Success(data, result.Code, result.Message);
        }
    }

    internal class PaginationResult<T> : Result<IEnumerable<T>>, IPaginationResult<T>
    {
        public int Page { get; }
        public int Size { get; }
        public int TotalElements { get; }
        public int TotalPages { get; }
        private PaginationResult(
            bool success,
            IEnumerable<T> data,
            string? code,
            string? message,
            int page,
            int size,
            int totalElements,
            int totalPages) : base(success, data, code, message)
        {
            Page = page;
            Size = size;
            TotalElements = totalElements;
            TotalPages = totalPages;
        }

        public static IPaginationResult<T> Success(IEnumerable<T> data, int page, int size, int totalElements, int totalPages)
        {
            return new PaginationResult<T>(true, data, null, null, page, size, totalElements, totalPages);
        }

        public static new IPaginationResult<T> Fail(string? code = null, string? message = null)
        {
            return new PaginationResult<T>(false, [], code, message, 0, 0, 0, 0);
        }

        public static IPaginationResult<T> FromResult<S>(IPaginationResult<S> result, IEnumerable<T> data)
        {
            if (result.IsSuccess)
                return (IPaginationResult<T>)result;
            return PaginationResult<T>.Success(data, result.Page, result.Size, result.TotalElements,
                result.TotalPages);
        }
    }
}
