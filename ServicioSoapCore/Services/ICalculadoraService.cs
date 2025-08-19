using System.ServiceModel;

namespace ServicioSoapCore.Services
{
    [ServiceContract]
    public interface ICalculadoraService
    {
        [OperationContract]
        int Sumar(int a, int b);

        [OperationContract]
        int Restar(int a, int b);
    }
}
