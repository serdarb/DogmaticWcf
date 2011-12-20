using System.ServiceModel;

namespace DogmaticWcf.Server.Contracts
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        string DoSomething(MyDto data);
    }
}