namespace ApplicationLogic.Abstractions.UseCase
{
    public interface IUseCase<IRequest, IResponse> where IRequest : class, new()  where IResponse : class, new()
    {
        public Task<IResponse> ExecuteAsync(IRequest request); 
    }
    public interface IUseCase<IRequest> where IRequest : class, new()
    {
        public Task ExecuteAsync(IRequest request);
    }
}
