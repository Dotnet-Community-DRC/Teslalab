namespace Teslalab.Shared
{
    public class OperationResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}