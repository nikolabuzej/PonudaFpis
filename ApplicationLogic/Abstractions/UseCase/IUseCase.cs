namespace ApplicationLogic.Abstractions.UseCase
{
    public interface IUseCase<TRequest, TResponse> where TRequest: IRequest where TResponse : IResponse
    {
        public Task<TResponse> ExecuteAsync(TRequest request); 
    }
    public interface IUseCase<TRequest> where TRequest : IRequest
    {
        public Task ExecuteAsync(TRequest request);
    }
}
