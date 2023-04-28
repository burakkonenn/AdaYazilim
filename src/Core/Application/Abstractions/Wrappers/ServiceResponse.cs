namespace Application.Abstractions.Wrappers
{
    public class ServiceResponse
    {
        public string Message { get; set; }
        public bool IsReservationRequestSuccees { get; set; }
    }
    public partial class ServiceResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }
}
