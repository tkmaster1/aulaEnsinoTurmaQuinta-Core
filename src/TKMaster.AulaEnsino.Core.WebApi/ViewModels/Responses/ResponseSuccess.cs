namespace TKMaster.AulaEnsino.Core.WebApi.ViewModels.Responses
{
    public class ResponseSuccess<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }
    }
}
