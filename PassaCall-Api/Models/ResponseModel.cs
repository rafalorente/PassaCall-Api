namespace PassaCall_Api.Models
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Stats { get; set; } = true;
    }
}
